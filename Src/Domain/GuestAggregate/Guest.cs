// <copyright file="Guest.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Bill.ValueObjects;
using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.Dinner.ValueObjects;
using Domain.Guest.ValueObjects;
using Domain.MenuReview.ValueObjects;
using Domain.User.ValueObjects;

namespace Domain.Guest
{
    public sealed class Guest : AggregateRoot<GuestId, Guid>
    {
        private readonly List<DinnerId> _upcomingDinnerIds = new ();
        private readonly List<DinnerId> _pastDinnerIds = new ();
        private readonly List<DinnerId> _pendingDinnerIds = new ();
        private readonly List<BillId> _billIds = new ();
        private readonly List<MenuReviewId> _menuReviewIds = new ();
        private readonly List<Rating> _ratings = new ();

        public string FirstName { get; }
        public string LastName { get; }
        public string ProfileImage { get; }
        public float AverageRating { get; }
        public UserId UserId { get; }
        public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
        public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        public Guest(
            GuestId guestId,
            string firstName,
            string lastName,
            string profileImage,
            float averageRating,
            UserId userId,
            DateTime createdDateTime,
            DateTime updatedDateTime)
            : base(guestId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Guest Create(
            string firstName,
            string lastName,
            string profileImage,
            float averageRating,
            UserId userId,
            DateTime createdDateTime,
            DateTime updatedDateTime)
        {
            return new Guest(
                GuestId.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                averageRating,
                userId,
                createdDateTime,
                updatedDateTime);
        }
    }
}
