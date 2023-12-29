// <copyright file="IDomainEvent.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using MediatR;

namespace Domain.Common.Models
{
    public interface IDomainEvent : INotification
    {
    }
}
