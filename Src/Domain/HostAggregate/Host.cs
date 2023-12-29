// <copyright file="Host.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Bill.ValueObjects;
using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.Dinner.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.MenuReview.ValueObjects;
using Domain.User.ValueObjects;

namespace Domain.Host
{
    public class Host : AggregateRoot<HostId, Guid>
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
        public double AverageRating { get; }
        public UserId UserId { get; }
        public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
        public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        public Host(HostId id, string firstName, string lastName, string profileImage, double averageRating, UserId userId, DateTime createdDateTime, DateTime updatedDateTime)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Host Create(string firstName, string lastName, string profileImage, double averageRating, UserId userId, DateTime createdDateTime, DateTime updatedDateTime)
        {
            return new Host(
                HostId.CreateUnique(),
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
