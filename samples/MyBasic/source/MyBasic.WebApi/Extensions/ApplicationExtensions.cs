namespace MyBasic.WebApi.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<MyBasic.Application.Boundaries.CloseAccount.IUseCase, MyBasic.Application.UseCases.CloseAccount>();
            services.AddScoped<MyBasic.Application.Boundaries.Deposit.IUseCase, MyBasic.Application.UseCases.Deposit>();
            services.AddScoped<MyBasic.Application.Boundaries.GetAccountDetails.IUseCase, MyBasic.Application.UseCases.GetAccountDetails>();
            services.AddScoped<MyBasic.Application.Boundaries.GetCustomerDetails.IUseCase, MyBasic.Application.UseCases.GetCustomerDetails>();
            services.AddScoped<MyBasic.Application.Boundaries.Register.IUseCase, MyBasic.Application.UseCases.Register>();
            services.AddScoped<MyBasic.Application.Boundaries.Withdraw.IUseCase, MyBasic.Application.UseCases.Withdraw>();
            services.AddScoped<MyBasic.Application.Boundaries.Transfer.IUseCase, MyBasic.Application.UseCases.Transfer>();

            return services;
        }
    }
}