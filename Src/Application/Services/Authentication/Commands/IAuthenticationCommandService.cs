// <copyright file="IAuthenticationCommandService.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Application.Services.Authentication.Common;

using ErrorOr;

namespace Application.Services.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
        ErrorOr<AuthenticationResult> Register(string firstname, string lastname, string email, string password);
    }
}
