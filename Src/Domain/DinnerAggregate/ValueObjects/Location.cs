// <copyright file="Location.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;

namespace Domain.Dinner.ValueObjects
{
    public class Location : ValueObject
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Location(string name, string address, decimal latitude, decimal longitude)
        {
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        public static Location CreateUnique(
            string name,
            string address,
            decimal latitude,
            decimal longitude)
        {
            return new (
                name,
                address,
                latitude,
                longitude);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Address;
            yield return Latitude;
            yield return Longitude;
        }
    }
}
