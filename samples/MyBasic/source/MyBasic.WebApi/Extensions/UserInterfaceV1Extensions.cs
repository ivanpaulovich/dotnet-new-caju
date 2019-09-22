namespace MyBasic.WebApi.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class UserInterfaceV1Extensions
    {
        public static IServiceCollection AddPresentersV1(this IServiceCollection services)
        {

            services.AddScoped<MyBasic.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter, MyBasic.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter>();
            services.AddScoped<MyBasic.Application.Boundaries.GetCustomerDetails.IOutputPort>(x => x.GetRequiredService<MyBasic.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter>());

            services.AddScoped<MyBasic.WebApi.UseCases.V1.Register.RegisterPresenter, MyBasic.WebApi.UseCases.V1.Register.RegisterPresenter>();
            services.AddScoped<MyBasic.Application.Boundaries.Register.IOutputPort>(x => x.GetRequiredService<MyBasic.WebApi.UseCases.V1.Register.RegisterPresenter>());


            return services;
        }
    }
}