// <copyright file="GuestRating.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;
using Domain.Dinner.ValueObjects;
using Domain.Guest.ValueObjects;
using Domain.Host.ValueObjects;

namespace Domain.Guest.Entities
{
    public class GuestRating : Entity<GuestRatingId>
    {
        public HostId HostId { get; }
        public DinnerId DinnerId { get; }
        public int RatingValue { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        public GuestRating(
            GuestRatingId id,
            HostId hostId,
            DinnerId dinnerId,
            int ratingValue,
            DateTime createdDateTime,
            DateTime updatedDateTime)
            : base(id)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            RatingValue = ratingValue;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static GuestRating Create(
            HostId hostId,
            DinnerId dinnerId,
            int ratingValue,
            DateTime createdDateTime,
            DateTime updatedDateTime)
        {
            return new (
                GuestRatingId.CreateUnique(),
                hostId,
                dinnerId,
                ratingValue,
                createdDateTime,
                updatedDateTime);
        }
    }
}
