// <copyright file="GuestId.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;
namespace Domain.Guest.ValueObjects
{
    public class GuestId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }
        private GuestId(Guid value)
        {
            Value = value;
        }

        public static GuestId CreateUnique()
        {
            return new (Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
