// <copyright file="LoginRequest.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

namespace Contract.Authentication
{
    public record LoginRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password);
}
