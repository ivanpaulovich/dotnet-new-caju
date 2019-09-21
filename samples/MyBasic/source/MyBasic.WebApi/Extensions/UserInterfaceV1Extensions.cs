namespace MyBasic.WebApi.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class UserInterfaceV1Extensions
    {
        public static IServiceCollection AddPresentersV1(this IServiceCollection services)
        {
            services.AddScoped<MyBasic.WebApi.UseCases.V1.CloseAccount.CloseAccountPresenter, MyBasic.WebApi.UseCases.V1.CloseAccount.CloseAccountPresenter>();
            services.AddScoped<MyBasic.Application.Boundaries.CloseAccount.IOutputPort>(x => x.GetRequiredService<MyBasic.WebApi.UseCases.V1.CloseAccount.CloseAccountPresenter>());

            services.AddScoped<MyBasic.WebApi.UseCases.V1.Deposit.DepositPresenter, MyBasic.WebApi.UseCases.V1.Deposit.DepositPresenter>();
            services.AddScoped<MyBasic.Application.Boundaries.Deposit.IOutputHandler>(x => x.GetRequiredService<MyBasic.WebApi.UseCases.V1.Deposit.DepositPresenter>());

            services.AddScoped<MyBasic.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter, MyBasic.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter>();
            services.AddScoped<MyBasic.Application.Boundaries.GetAccountDetails.IOutputPort>(x => x.GetRequiredService<MyBasic.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter>());

            services.AddScoped<MyBasic.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter, MyBasic.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter>();
            services.AddScoped<MyBasic.Application.Boundaries.GetCustomerDetails.IOutputPort>(x => x.GetRequiredService<MyBasic.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter>());

            services.AddScoped<MyBasic.WebApi.UseCases.V1.Register.RegisterPresenter, MyBasic.WebApi.UseCases.V1.Register.RegisterPresenter>();
            services.AddScoped<MyBasic.Application.Boundaries.Register.IOutputPort>(x => x.GetRequiredService<MyBasic.WebApi.UseCases.V1.Register.RegisterPresenter>());

            services.AddScoped<MyBasic.WebApi.UseCases.V1.Withdraw.WithdrawPresenter, MyBasic.WebApi.UseCases.V1.Withdraw.WithdrawPresenter>();
            services.AddScoped<MyBasic.Application.Boundaries.Withdraw.IOutputPort>(x => x.GetRequiredService<MyBasic.WebApi.UseCases.V1.Withdraw.WithdrawPresenter>());

            services.AddScoped<MyBasic.WebApi.UseCases.V1.Transfer.TransferPresenter, MyBasic.WebApi.UseCases.V1.Transfer.TransferPresenter>();
            services.AddScoped<MyBasic.Application.Boundaries.Transfer.IOutputPort>(x => x.GetRequiredService<MyBasic.WebApi.UseCases.V1.Transfer.TransferPresenter>());

            return services;
        }
    }
}