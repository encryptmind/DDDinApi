// <copyright file="AuthenticationResponse.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

namespace Contract.Authentication
{
    public record AuthenticationResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token);
}
