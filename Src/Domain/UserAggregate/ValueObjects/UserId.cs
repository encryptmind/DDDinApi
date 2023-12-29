// <copyright file="UserId.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;

namespace Domain.User.ValueObjects
{
    public class UserId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        public static UserId Create(Guid value)
        {
            return new(value);
        }

        private UserId(Guid value)
        {
            Value = value;
        }

        public static UserId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
