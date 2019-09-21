namespace MyReadOnly.WebApi.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class UserInterfaceV1Extensions
    {
        public static IServiceCollection AddPresentersV1(this IServiceCollection services)
        {
            services.AddScoped<MyReadOnly.WebApi.UseCases.V1.CloseAccount.CloseAccountPresenter, MyReadOnly.WebApi.UseCases.V1.CloseAccount.CloseAccountPresenter>();
            services.AddScoped<MyReadOnly.Application.Boundaries.CloseAccount.IOutputPort>(x => x.GetRequiredService<MyReadOnly.WebApi.UseCases.V1.CloseAccount.CloseAccountPresenter>());

            services.AddScoped<MyReadOnly.WebApi.UseCases.V1.Deposit.DepositPresenter, MyReadOnly.WebApi.UseCases.V1.Deposit.DepositPresenter>();
            services.AddScoped<MyReadOnly.Application.Boundaries.Deposit.IOutputHandler>(x => x.GetRequiredService<MyReadOnly.WebApi.UseCases.V1.Deposit.DepositPresenter>());

            services.AddScoped<MyReadOnly.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter, MyReadOnly.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter>();
            services.AddScoped<MyReadOnly.Application.Boundaries.GetAccountDetails.IOutputPort>(x => x.GetRequiredService<MyReadOnly.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter>());

            services.AddScoped<MyReadOnly.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter, MyReadOnly.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter>();
            services.AddScoped<MyReadOnly.Application.Boundaries.GetCustomerDetails.IOutputPort>(x => x.GetRequiredService<MyReadOnly.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter>());

            services.AddScoped<MyReadOnly.WebApi.UseCases.V1.Register.RegisterPresenter, MyReadOnly.WebApi.UseCases.V1.Register.RegisterPresenter>();
            services.AddScoped<MyReadOnly.Application.Boundaries.Register.IOutputPort>(x => x.GetRequiredService<MyReadOnly.WebApi.UseCases.V1.Register.RegisterPresenter>());

            services.AddScoped<MyReadOnly.WebApi.UseCases.V1.Withdraw.WithdrawPresenter, MyReadOnly.WebApi.UseCases.V1.Withdraw.WithdrawPresenter>();
            services.AddScoped<MyReadOnly.Application.Boundaries.Withdraw.IOutputPort>(x => x.GetRequiredService<MyReadOnly.WebApi.UseCases.V1.Withdraw.WithdrawPresenter>());

            services.AddScoped<MyReadOnly.WebApi.UseCases.V1.Transfer.TransferPresenter, MyReadOnly.WebApi.UseCases.V1.Transfer.TransferPresenter>();
            services.AddScoped<MyReadOnly.Application.Boundaries.Transfer.IOutputPort>(x => x.GetRequiredService<MyReadOnly.WebApi.UseCases.V1.Transfer.TransferPresenter>());

            return services;
        }
    }
}