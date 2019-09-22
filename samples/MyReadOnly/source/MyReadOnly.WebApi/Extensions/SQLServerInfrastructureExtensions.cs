namespace MyReadOnly.WebApi.Extensions
{
    using MyReadOnly.Application.Repositories;
    using MyReadOnly.Application.Services;
    using MyReadOnly.Domain;
    using MyReadOnly.Infrastructure.EntityFrameworkDataAccess;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class SQLServerInfrastructureExtensions
    {
        public static IServiceCollection AddSQLServerPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEntityFactory, EntityFactory>();

            services.AddDbContext<MyReadOnlyContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}