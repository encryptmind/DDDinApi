// <copyright file="IUserRepository.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.User;

namespace Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}
