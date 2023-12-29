// <copyright file="BillId.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;

namespace Domain.Bill.ValueObjects
{
    public class BillId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private BillId(Guid value)
        {
            Value = value;
        }

        public static BillId CreateUnique()
        {
            return new (Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
