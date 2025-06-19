using Social.Media.Application.Common.Interfaces;
using Social.Media.Infrastructure.Persistence;
using Social.Media.Infrastructure.Services.Authentication;
using System.Reflection;

namespace Social.Media.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPasswordService, IPasswordService>();
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // AutoMapper - it maps between Application DTOs and Domain Entities
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // MediatR - Handlers for Commands/Queries live here
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}

