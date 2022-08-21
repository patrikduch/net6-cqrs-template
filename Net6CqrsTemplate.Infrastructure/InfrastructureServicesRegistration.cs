namespace Net6CqrsTemplate.Infrastructure;

using Microsoft.Extensions.DependencyInjection;
using Net6CqrsTemplate.Application.Contracts.Infrastructure.Services;
using Net6CqrsTemplate.Infrastructure.Services;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IZipFileService, ZipFileService>();

        return services;
    }
}
