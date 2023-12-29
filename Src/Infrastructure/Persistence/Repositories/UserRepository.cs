// <copyright file="UserRepository.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Application.Common.Interfaces.Persistence;

using Domain.User;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new List<User>();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);
        }
    }
}
