// <copyright file="Dinner.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;
using Domain.Dinner.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Menu.ValueObjects;

namespace Domain.Dinner
{
    public class Dinner : AggregateRoot<DinnerId, Guid>
    {
        private readonly List<ReservationId> _reservationIds = new ();
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime? StartedDateTime { get; set; }
        public DateTime? EndedDateTime { get; set; }
        public string Status { get; set; }
        public bool IsPublic { get; set; }
        public int MaxGuests { get; set; }
        public Price Price { get; set; }
        public HostId HostId { get; set; }
        public MenuId MenuId { get; set; }
        public string ImageUrl { get; set; }
        public Location Location { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public IReadOnlyCollection<ReservationId> ReservationIds => _reservationIds.AsReadOnly();
        public Dinner(
            DinnerId id,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            string status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location)
            : base(id)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Status = status;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
        }

        public static Dinner Create(
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            string status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location)
        {
            var dinner = new Dinner(
               DinnerId.CreateUnique(),
               name,
               description,
               startDateTime,
               endDateTime,
               status,
               isPublic,
               maxGuests,
               price,
               hostId,
               menuId,
               imageUrl,
               location);

            return dinner;
        }
    }
}
