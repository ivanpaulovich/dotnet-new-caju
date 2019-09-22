namespace MyReadOnly.WebApi.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class UserInterfaceV1Extensions
    {
        public static IServiceCollection AddPresentersV1(this IServiceCollection services)
        {
            services.AddScoped<MyReadOnly.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter, MyReadOnly.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter>();
            services.AddScoped<MyReadOnly.Application.Boundaries.GetAccountDetails.IOutputPort>(x => x.GetRequiredService<MyReadOnly.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter>());
            services.AddScoped<MyReadOnly.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter, MyReadOnly.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter>();
            services.AddScoped<MyReadOnly.Application.Boundaries.GetCustomerDetails.IOutputPort>(x => x.GetRequiredService<MyReadOnly.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter>());
            return services;
        }
    }
}