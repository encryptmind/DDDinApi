// <copyright file="MenuConfiguration.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Host.ValueObjects;
using Domain.Menu;
using Domain.Menu.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    internal class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);
            ConfigureMenuSectionTable(builder);
            ConfigureMenuDinnerIdsTable(builder);
            ConfigureMenuReviewIdsTable(builder);
        }

        private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.DinnerIds, di =>
            {
                di.ToTable("MenuDinnerIds");

                di.WithOwner().HasForeignKey("MenuId");

                di.HasKey("Id");

                di.Property(d => d.Value)
                    .HasColumnName("DinnerId")
                    .ValueGeneratedNever();
            });
            builder.Metadata.FindNavigation(nameof(Menu.DinnerIds)) !
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.MenuReviewIds, di =>
            {
                di.ToTable("MenuReviewIds");

                di.WithOwner().HasForeignKey("MenuId");

                di.HasKey("Id");

                di.Property(d => d.Value)
                    .HasColumnName("ReviewId")
                    .ValueGeneratedNever();
            });
            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds)) !
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuSectionTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.Sections, sb =>
            {
                sb.ToTable("MenuSections");

                sb.Property(m => m.Id)
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value));

                sb.WithOwner().HasForeignKey("MenuId");

                sb.HasKey("Id", "MenuId");

                sb.Property(m => m.Name)
                    .HasMaxLength(100);

                sb.Property(m => m.Description)
                    .HasMaxLength(100);

                sb.OwnsMany(s => s.Items, ib =>
                {
                    ib.ToTable("MenuItems");

                    ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                    ib.HasKey("Id", "MenuSectionId", "MenuId");
                    ib.Property(m => m.Id)
                        .HasColumnName("MenuItemId")
                        .ValueGeneratedNever()
                        .HasConversion(
                            id => id.Value,
                            value => MenuItemId.Create(value));

                    ib.Property(m => m.Name)
                        .HasMaxLength(100);

                    ib.Property(m => m.Description)
                        .HasMaxLength(100);
                });
                sb.Navigation(s => s.Items).Metadata.SetField("_items");
                sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.Metadata.FindNavigation(nameof(Menu.Sections)) !
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

            builder.OwnsOne(m => m.AverageRating);

            builder.Property(m => m.HostId)
                .HasConversion(
                id => id.Value,
                value => HostId.Create(value));
        }
    }
}
