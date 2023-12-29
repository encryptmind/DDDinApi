// <copyright file="LoginCommandHandler.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

namespace Application.Authentication.Queries.Login
{
    using System.Threading.Tasks;

    using Application.Common.Interfaces.Authentication;
    using Application.Common.Interfaces.Persistence;
    using Application.Services.Authentication.Common;

    using Domain.Common.Errors;
    using Domain.User;

    using ErrorOr;

    using MediatR;

    public class LoginCommandHandler :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // 1. Validate the user exists
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // 2. Validate the password is correct
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // 3. Create Jwt token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
