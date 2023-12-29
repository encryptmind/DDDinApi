// <copyright file="Menu.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.Dinner.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Menu.Entities;
using Domain.Menu.ValueObjects;
using Domain.MenuAggregate.Events;
using Domain.MenuReview.ValueObjects;

namespace Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId, Guid>
    {
        private readonly List<MenuSection> _sections = new ();
        private readonly List<DinnerId> _dinnerIds = new ();
        private readonly List<MenuReviewId> _menuReviewIds = new ();

        private readonly List<IDomainEvent> _domainEvent = new ();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public AverageRating AverageRating { get; private set; }
        public HostId HostId { get; private set; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public DateTime CreatedDatetime { get; private set; }
        public DateTime UpdatedDatetime { get; private set; }

        private Menu(
            MenuId menuId,
            string name,
            string description,
            AverageRating averageRating,
            HostId hostId,
            List<MenuSection> menuSections,
            DateTime createdDatetime,
            DateTime updatedDatetime)
            : base(menuId)
        {
            Name = name;
            Description = description;
            AverageRating = averageRating;
            HostId = hostId;
            CreatedDatetime = createdDatetime;
            UpdatedDatetime = updatedDatetime;
            _sections = menuSections;
        }

        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Menu()
        {
        }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        // float averageRating,
        // DateTime createdDatetime,
        // DateTime updatedDatetime
        public static Menu Create(
            HostId hostId,
            string name,
            string descriptoin,
            List<MenuSection> menuSections)
        {
            var menu = new Menu(
                MenuId.CreateUnique(),
                name,
                descriptoin,
                AverageRating.CreateNew(0, 0),
                hostId,
                menuSections,
                DateTime.Now,
                DateTime.Now);

            menu.AddDomainEvent(new MenuCreate(menu));
            return menu;
        }
    }
}
