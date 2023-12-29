// <copyright file="DependencyInjection.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using System.Reflection;
using Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
            // services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            // services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            return services;
        }
    }
}
