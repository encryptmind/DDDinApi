// <copyright file="IJwtTokenGenerator.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.User;

namespace Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
