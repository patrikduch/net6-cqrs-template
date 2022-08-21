namespace Net6CqrsTemplate.Application;

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using FluentValidation;

public static class ApplicationServicesRegistration    
{
        
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)    
    {    
        services.AddAutoMapper(Assembly.GetExecutingAssembly());   
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());    
        services.AddMediatR(Assembly.GetExecutingAssembly());
    
        return services;        
    }
}
