// <copyright file="IHasDomainEvents.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

namespace Domain.Common.Models
{
    public interface IHasDomainEvents
    {
        public IReadOnlyList<IDomainEvent> DomainEvents { get; }
        public void ClearDomainEvents();
    }
}
