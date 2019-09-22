namespace MyReadOnly.WebApi.Extensions
{
    using MyReadOnly.Application.Repositories;
    using MyReadOnly.Application.Services;
    using MyReadOnly.Domain;
    using MyReadOnly.Infrastructure.InMemoryDataAccess.Repositories;
    using MyReadOnly.Infrastructure.InMemoryDataAccess;
    using Microsoft.Extensions.DependencyInjection;

    public static class InMemoryInfrastructureExtensions
    {
        public static IServiceCollection AddInMemoryPersistence(this IServiceCollection services)
        {
            services.AddScoped<IEntityFactory, EntityFactory>();

            services.AddSingleton<MyReadOnlyContext, MyReadOnlyContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}