namespace MyReadOnly.WebApi.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<MyReadOnly.Application.Boundaries.GetAccountDetails.IUseCase, MyReadOnly.Application.UseCases.GetAccountDetails>();
            services.AddScoped<MyReadOnly.Application.Boundaries.GetCustomerDetails.IUseCase, MyReadOnly.Application.UseCases.GetCustomerDetails>();
            return services;
        }
    }
}