// <copyright file="LoginQueryValidator.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using FluentValidation;

namespace Application.Authentication.Queries.Login
{
    internal class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
