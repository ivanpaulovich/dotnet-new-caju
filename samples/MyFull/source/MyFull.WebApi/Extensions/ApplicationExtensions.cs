namespace MyFull.WebApi.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<MyFull.Application.Boundaries.CloseAccount.IUseCase, MyFull.Application.UseCases.CloseAccount>();
            services.AddScoped<MyFull.Application.Boundaries.Deposit.IUseCase, MyFull.Application.UseCases.Deposit>();
            services.AddScoped<MyFull.Application.Boundaries.GetAccountDetails.IUseCase, MyFull.Application.UseCases.GetAccountDetails>();
            services.AddScoped<MyFull.Application.Boundaries.GetCustomerDetails.IUseCase, MyFull.Application.UseCases.GetCustomerDetails>();
            services.AddScoped<MyFull.Application.Boundaries.Register.IUseCase, MyFull.Application.UseCases.Register>();
            services.AddScoped<MyFull.Application.Boundaries.Withdraw.IUseCase, MyFull.Application.UseCases.Withdraw>();
            services.AddScoped<MyFull.Application.Boundaries.Transfer.IUseCase, MyFull.Application.UseCases.Transfer>();

            return services;
        }
    }
}