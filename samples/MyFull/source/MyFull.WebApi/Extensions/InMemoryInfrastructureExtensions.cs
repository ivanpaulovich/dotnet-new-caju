namespace MyFull.WebApi.Extensions
{
    using MyFull.Application.Repositories;
    using MyFull.Application.Services;
    using MyFull.Domain;
    using MyFull.Infrastructure.InMemoryDataAccess.Repositories;
    using MyFull.Infrastructure.InMemoryDataAccess;
    using Microsoft.Extensions.DependencyInjection;

    public static class InMemoryInfrastructureExtensions
    {
        public static IServiceCollection AddInMemoryPersistence(this IServiceCollection services)
        {
            services.AddScoped<IEntityFactory, EntityFactory>();

            services.AddSingleton<MyFullContext, MyFullContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}