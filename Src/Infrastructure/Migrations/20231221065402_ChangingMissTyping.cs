// <copyright file="20231221065402_ChangingMissTyping.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangingMissTyping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descriptoin",
                table: "MenuItems",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "MenuItems",
                newName: "Descriptoin");
        }
    }
}
