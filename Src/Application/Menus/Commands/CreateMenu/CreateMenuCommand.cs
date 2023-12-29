// <copyright file="CreateMenuCommand.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Menu;

using ErrorOr;

using MediatR;

namespace Application.Menus.Commands.CreateMenu
{
    public record CreateMenuCommand(
        string Name,
        string Description,
        string HostId,
        List<MenuSectionCommand> Sections)
        : IRequest<ErrorOr<Menu>>;

    public record MenuSectionCommand(
        string Name,
        string Description,
        List<MenuItemCommand> Items);

    public record MenuItemCommand(
        string Name,
        string Description);
}
