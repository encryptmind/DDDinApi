// <copyright file="MenuItem.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;
using Domain.Menu.ValueObjects;

namespace Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; }
        public string Description { get; }
        public MenuItem(MenuItemId id, string name, string Description)
            : base(id)
        {
            Name = name;
            this.Description = Description;
        }

        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MenuItem()
        {
        }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public static MenuItem Create(
            string name,
            string Description)
        {
            return new (
                MenuItemId.CreateUnique(),
                name,
                Description);
        }
    }
}
