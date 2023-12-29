// <copyright file="MenuSection.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;
using Domain.Menu.ValueObjects;

namespace Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new ();
        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(
            MenuSectionId id,
            string name,
            string descriptoin,
            List<MenuItem> items)
            : base(id)
        {
            Name = name;
            Description = descriptoin;
            _items = items;
        }

        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MenuSection()
        {
        }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public string Name { get; }
        public string Description { get; }

        public static MenuSection Create(
            string name,
            string descrption,
            List<MenuItem> menuItems)
        {
            return new (
                MenuSectionId.CreateUnique(),
                name,
                descrption,
                menuItems);
        }
    }
}
