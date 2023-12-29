// <copyright file="IDateTimeProvider.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

namespace Application.Common.Services
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
