namespace MyBasic.WebApi.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<MyBasic.Application.Boundaries.GetCustomerDetails.IUseCase, MyBasic.Application.UseCases.GetCustomerDetails>();
            services.AddScoped<MyBasic.Application.Boundaries.Register.IUseCase, MyBasic.Application.UseCases.Register>();
            return services;
        }
    }
}