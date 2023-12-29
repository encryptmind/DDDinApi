// <copyright file="CreateMenuCommandUtils.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Application.Menus.Commands.CreateMenu;

namespace DDDinApi.Application.UnitTests.Menus.TestUtils
{
    public static class CreateMenuCommandUtils
    {
        public static CreateMenuCommand CreateCommand(
            List<MenuSectionCommand>? sections = null) =>
            new CreateMenuCommand(
                Constants.Constants.Menu.Name,
                Constants.Constants.Menu.Description,
                Constants.Constants.Host.Id.Value.ToString() !,
                sections ?? CreateSectionsCommand());
        public static List<MenuSectionCommand> CreateSectionsCommand(
            int sectionCount = 1,
            List<MenuItemCommand>? items = null) =>
            Enumerable.Range(0, sectionCount)
                .Select(index => new MenuSectionCommand(
                    Constants.Constants.Menu.SectionNameFromIndex(index),
                    Constants.Constants.Menu.SectionDescriptionFromIndex(index),
                    items ?? CreateItemsCommand())).ToList();
        public static List<MenuItemCommand> CreateItemsCommand(int itemCount = 1) =>
            Enumerable.Range(0, itemCount)
                .Select(index => new MenuItemCommand(
                    Constants.Constants.Menu.SectionNameFromIndex(index),
                    Constants.Constants.Menu.SectionDescriptionFromIndex(index))).ToList();
    }
}
