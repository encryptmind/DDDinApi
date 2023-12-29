// <copyright file="IMenuRepository.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Menu;

namespace Application.Common.Interfaces.Persistence
{
    public interface IMenuRepository
    {
        void AddMenu(Menu menu);
    }
}
