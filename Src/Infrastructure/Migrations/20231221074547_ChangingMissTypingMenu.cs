// <copyright file="20231221074547_ChangingMissTypingMenu.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangingMissTypingMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descriptoin",
                table: "Menu",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Menu",
                newName: "Descriptoin");
        }
    }
}
