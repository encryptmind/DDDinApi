// <copyright file="DinnerId.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;

namespace Domain.Dinner.ValueObjects
{
    public class DinnerId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }
        private DinnerId(Guid value)
        {
            Value = value;
        }

        private DinnerId()
        {
        }

        public static DinnerId CreateUnique()
        {
            return new (Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
