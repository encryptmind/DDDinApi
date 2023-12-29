// <copyright file="IAuthenticationQueryService.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Application.Services.Authentication.Common;

using ErrorOr;

namespace Application.Services.Authentication.Queries
{
    public interface IAuthenticationQueryService
    {
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}
