// <copyright file="CreateMenuCommandValidator.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using FluentValidation;

namespace Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Sections).NotEmpty();
        }
    }
}
