// <copyright file="MenuMappingConfig.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Application.Menus.Commands.CreateMenu;

using Contract.Menus;

using Domain.Menu;
using Domain.Menu.ValueObjects;

using Mapster;

using MenuItem = Domain.Menu.Entities.MenuItem;
using MenuSection = Domain.Menu.Entities.MenuSection;

namespace Service.Api.Common.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request, string hostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.hostId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => MenuId.Create(src.Id.Value).Value)
                .Map(dest => dest.AverageRating, src => src.AverageRating.GetAverageRating())
                .Map(dest => dest.HostId, src => src.HostId.Value.ToString())
                .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value).ToList())
                .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value).ToList());

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value.ToString());

            config.NewConfig<MenuItem, MenuItemResponse>()
               .Map(dest => dest.Id, src => src.Id.Value.ToString());
        }
    }
}
