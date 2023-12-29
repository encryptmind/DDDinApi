// <copyright file="CreateMenuCommandHandlerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Application.Common.Interfaces.Persistence;
using Application.Menus.Commands.CreateMenu;

using DDDinApi.Application.UnitTests.Menus.TestUtils;
using DDDinApi.Application.UnitTests.TestUtils.Menus.Extensions;

using FluentAssertions;

using Moq;

namespace DDDinApi.Application.UnitTests.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandlerTests
    {
        private readonly CreateMenuCommandHandler _handler;
        private readonly Mock<IMenuRepository> _mockMenuRepository;

        public CreateMenuCommandHandlerTests()
        {
            _mockMenuRepository = new Mock<IMenuRepository>();
            _handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);
        }

        public static IEnumerable<object[]> ValidCreateMenuCommands()
        {
            yield return new[] { CreateMenuCommandUtils.CreateCommand() };
            yield return new[]
            {
                CreateMenuCommandUtils.CreateCommand(
                    sections: CreateMenuCommandUtils.CreateSectionsCommand(sectionCount: 3)),
            };
            yield return new[]
            {
                CreateMenuCommandUtils.CreateCommand(
                    sections: CreateMenuCommandUtils.CreateSectionsCommand(
                        sectionCount: 3,
                        items: CreateMenuCommandUtils.CreateItemsCommand(itemCount: 3))),
            };
        }

        [Theory]
        [MemberData(nameof(ValidCreateMenuCommands))]
        public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
        {
            // Act
            // Invoke the handler
            var result = await _handler.Handle(createMenuCommand, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(createMenuCommand);
            _mockMenuRepository.Verify(m => m.AddMenu(result.Value), Times.Once);
        }
    }
}
