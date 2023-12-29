// <copyright file="MenuRepository.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Application.Common.Interfaces.Persistence;

using Domain.Menu;

namespace Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly DDDInApiDbContext _dbContext;

        public MenuRepository(DDDInApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddMenu(Menu menu)
        {
            _dbContext.Menus.Add(menu);
            _dbContext.SaveChanges();
        }
    }
}
