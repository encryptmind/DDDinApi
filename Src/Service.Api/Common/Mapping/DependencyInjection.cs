// <copyright file="DependencyInjection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Mapster;

using MapsterMapper;

using Microsoft.AspNetCore.Mvc.Infrastructure;

using Service.Api.Common.Error;

using System.Reflection;

namespace Service.Api.Common.Mapping
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, DefaultProblemDetailsFactory>();

            return services;
        }
    }
}
