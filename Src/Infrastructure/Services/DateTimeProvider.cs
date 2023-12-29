// <copyright file="DateTimeProvider.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Application.Common.Services;

namespace Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
