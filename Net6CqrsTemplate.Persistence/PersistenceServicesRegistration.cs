using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net6CqrsTemplate.Application.Contracts.Persistence;
using Net6CqrsTemplate.Application.Contracts.Persistence.Readers;
using Net6CqrsTemplate.Application.Contracts.Persistence.Services;
using Net6CqrsTemplate.Application.Contracts.Persistence.Uow;
using Net6CqrsTemplate.Application.Contracts.Persistence.Writters;
using Net6CqrsTemplate.Persistence.DbContexts;
using Net6CqrsTemplate.Persistence.Readers;
using Net6CqrsTemplate.Persistence.Repositories;
using Net6CqrsTemplate.Persistence.Services;
using Net6CqrsTemplate.Persistence.Uow;
using Net6CqrsTemplate.Persistence.Writers;

namespace Net6CqrsTemplate.Persistence
{
    public static class PersistenceServicesRegistration
    {

        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IValueService, ValueService>();
            services.AddScoped<IValueRepository, ValueRepository>();


            #region DatabaseSettings setup
            var connectionString = configuration.GetConnectionString("TestConnectionString");
            #endregion


            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddScoped<IValueWriter, ValueWriter>();
            services.AddScoped<IValueReader, ValueReader>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
