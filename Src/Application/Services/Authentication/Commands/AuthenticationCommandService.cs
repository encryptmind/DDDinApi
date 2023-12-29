// <copyright file="AuthenticationCommandService.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

namespace Application.Services.Authentication.Commands
{
    using Application.Common.Interfaces.Authentication;
    using Application.Common.Interfaces.Persistence;
    using Application.Common.Services;
    using Application.Services.Authentication.Common;

    using Domain.Common.Errors;
    using Domain.User;

    using ErrorOr;

    internal class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IDateTimeProvider dateTimeProvider)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public ErrorOr<AuthenticationResult> Register(string firstname, string lastname, string email, string password)
        {
            // 1. validate the user doesn't exist
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            // 2. Create user ( generate unique ID)  & persist to DB
            var user = User.Create(
                firstname,
                lastname,
                email,
                password,
                _dateTimeProvider.UtcNow,
                _dateTimeProvider.UtcNow);

            _userRepository.Add(user);

            // Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
