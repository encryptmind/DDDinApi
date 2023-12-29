// <copyright file="MenuReviewId.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;

namespace Domain.MenuReview.ValueObjects
{
    public class MenuReviewId : ValueObject
    {
        public Guid Value { get; }
        private MenuReviewId(Guid value)
        {
            Value = value;
        }

        public static MenuReviewId CreateUnique()
        {
            return new (Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
