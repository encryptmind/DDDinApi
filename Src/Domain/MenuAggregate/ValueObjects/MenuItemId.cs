// <copyright file="MenuItemId.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;

namespace Domain.Menu.ValueObjects
{
    public sealed class MenuItemId : ValueObject
    {
        private MenuItemId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static MenuItemId Create(Guid value)
        {
            return new MenuItemId(value);
        }

        public static MenuItemId CreateUnique()
        {
            return new (Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
