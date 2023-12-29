// <copyright file="CreateMenuCommandHandler.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Application.Common.Interfaces.Persistence;

using Domain.Host.ValueObjects;
using Domain.Menu;
using Domain.Menu.Entities;

using ErrorOr;

using MediatR;

namespace Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var menu = Menu.Create(
                HostId.Create(Guid.Parse(request.HostId)),
                request.Name,
                request.Description,
                request.Sections.ConvertAll(section => MenuSection.Create(
                    section.Name,
                    section.Description,
                    section.Items.ConvertAll(item => MenuItem.Create(
                        item.Name,
                        item.Description)))));

            _menuRepository.AddMenu(menu);

            return menu;
        }
    }
}
