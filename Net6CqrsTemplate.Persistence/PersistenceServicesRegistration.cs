using Microsoft.Extensions.DependencyInjection;
using Net6CqrsTemplate.Application.Contracts.Persistence;
using Net6CqrsTemplate.Application.Contracts.Persistence.Services;
using Net6CqrsTemplate.Persistence.Repositories;
using Net6CqrsTemplate.Persistence.Services;

namespace Net6CqrsTemplate.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IValueService, ValueService>();
            services.AddScoped<IValueRepository, ValueRepository>();

            return services;
        }
    }
}
