// <copyright file="RegisterRequest.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

namespace Contract.Authentication
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password);
}
