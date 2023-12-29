// <copyright file="AverageRating.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;

namespace Domain.Common.ValueObjects
{
    public class AverageRating : ValueObject
    {
        public AverageRating(decimal value, int numRating)
        {
            Value = value;
            NumRating = numRating;
        }

        public AverageRating()
        {
        }

        public decimal Value { get; private set; }
        public int NumRating { get; private set; }
        public static AverageRating CreateNew(decimal rating = 0, int numRating = 0)
        {
            return new AverageRating(rating, numRating);
        }

        public void AddNewRating(Rating rating)
        {
            Value = ((Value * NumRating) + rating.Value) / ++NumRating;
        }

        public void RemoveRating(Rating rating)
        {
            Value = ((Value * NumRating) - rating.Value) / --NumRating;
        }

        public float GetAverageRating()
        {
                return NumRating == 0 ? 0 : (float)Value / NumRating;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return NumRating;
        }
    }
}
