// <copyright file="AggregateRootId.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

namespace Domain.Common.Models
{
    public abstract class AggregateRootId<TId> : ValueObject
    {
        public abstract TId Value { get; protected set; }
    }
}
