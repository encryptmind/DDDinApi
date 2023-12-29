// <copyright file="DummyHandler.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.MenuAggregate.Events;

using MediatR;

namespace Application.Menus.Events
{
    internal class DummyHandler : INotificationHandler<MenuCreate>
    {
        public Task Handle(MenuCreate notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
