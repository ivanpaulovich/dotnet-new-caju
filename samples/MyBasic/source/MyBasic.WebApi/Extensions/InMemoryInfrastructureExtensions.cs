namespace MyBasic.WebApi.Extensions
{
    using MyBasic.Application.Repositories;
    using MyBasic.Application.Services;
    using MyBasic.Domain;
    using MyBasic.Infrastructure.InMemoryDataAccess.Repositories;
    using MyBasic.Infrastructure.InMemoryDataAccess;
    using Microsoft.Extensions.DependencyInjection;

    public static class InMemoryInfrastructureExtensions
    {
        public static IServiceCollection AddInMemoryPersistence(this IServiceCollection services)
        {
            services.AddScoped<IEntityFactory, EntityFactory>();

            services.AddSingleton<MyBasicContext, MyBasicContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}