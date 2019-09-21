namespace MyReadOnly.WebApi.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<MyReadOnly.Application.Boundaries.CloseAccount.IUseCase, MyReadOnly.Application.UseCases.CloseAccount>();
            services.AddScoped<MyReadOnly.Application.Boundaries.Deposit.IUseCase, MyReadOnly.Application.UseCases.Deposit>();
            services.AddScoped<MyReadOnly.Application.Boundaries.GetAccountDetails.IUseCase, MyReadOnly.Application.UseCases.GetAccountDetails>();
            services.AddScoped<MyReadOnly.Application.Boundaries.GetCustomerDetails.IUseCase, MyReadOnly.Application.UseCases.GetCustomerDetails>();
            services.AddScoped<MyReadOnly.Application.Boundaries.Register.IUseCase, MyReadOnly.Application.UseCases.Register>();
            services.AddScoped<MyReadOnly.Application.Boundaries.Withdraw.IUseCase, MyReadOnly.Application.UseCases.Withdraw>();
            services.AddScoped<MyReadOnly.Application.Boundaries.Transfer.IUseCase, MyReadOnly.Application.UseCases.Transfer>();

            return services;
        }
    }
}