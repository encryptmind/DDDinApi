// <copyright file="Rating.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;

namespace Domain.Common.ValueObjects
{
    public class Rating : ValueObject
    {
        public decimal Value { get; }
        private Rating(decimal value)
        {
            Value = value;
        }

        public static Rating CreateUnique(decimal value)
        {
            return new (value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
