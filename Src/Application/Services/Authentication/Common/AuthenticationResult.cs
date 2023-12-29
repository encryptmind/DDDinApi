// <copyright file="AuthenticationResult.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.User;

namespace Application.Services.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
