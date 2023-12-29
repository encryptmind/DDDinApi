// <copyright file="MenuCreated.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;

namespace Domain.MenuAggregate.Events
{
    public record MenuCreate(Domain.Menu.Menu menu): IDomainEvent;
}
