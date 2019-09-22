namespace MyFull.WebApi.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class UserInterfaceV1Extensions
    {
        public static IServiceCollection AddPresentersV1(this IServiceCollection services)
        {
            services.AddScoped<MyFull.WebApi.UseCases.V1.CloseAccount.CloseAccountPresenter, MyFull.WebApi.UseCases.V1.CloseAccount.CloseAccountPresenter>();
            services.AddScoped<MyFull.Application.Boundaries.CloseAccount.IOutputPort>(x => x.GetRequiredService<MyFull.WebApi.UseCases.V1.CloseAccount.CloseAccountPresenter>());
            services.AddScoped<MyFull.WebApi.UseCases.V1.Deposit.DepositPresenter, MyFull.WebApi.UseCases.V1.Deposit.DepositPresenter>();
            services.AddScoped<MyFull.Application.Boundaries.Deposit.IOutputPort>(x => x.GetRequiredService<MyFull.WebApi.UseCases.V1.Deposit.DepositPresenter>());
            services.AddScoped<MyFull.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter, MyFull.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter>();
            services.AddScoped<MyFull.Application.Boundaries.GetAccountDetails.IOutputPort>(x => x.GetRequiredService<MyFull.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter>());
            services.AddScoped<MyFull.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter, MyFull.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter>();
            services.AddScoped<MyFull.Application.Boundaries.GetCustomerDetails.IOutputPort>(x => x.GetRequiredService<MyFull.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter>());
            services.AddScoped<MyFull.WebApi.UseCases.V1.Register.RegisterPresenter, MyFull.WebApi.UseCases.V1.Register.RegisterPresenter>();
            services.AddScoped<MyFull.Application.Boundaries.Register.IOutputPort>(x => x.GetRequiredService<MyFull.WebApi.UseCases.V1.Register.RegisterPresenter>());
            services.AddScoped<MyFull.WebApi.UseCases.V1.Withdraw.WithdrawPresenter, MyFull.WebApi.UseCases.V1.Withdraw.WithdrawPresenter>();
            services.AddScoped<MyFull.Application.Boundaries.Withdraw.IOutputPort>(x => x.GetRequiredService<MyFull.WebApi.UseCases.V1.Withdraw.WithdrawPresenter>());
            services.AddScoped<MyFull.WebApi.UseCases.V1.Transfer.TransferPresenter, MyFull.WebApi.UseCases.V1.Transfer.TransferPresenter>();
            services.AddScoped<MyFull.Application.Boundaries.Transfer.IOutputPort>(x => x.GetRequiredService<MyFull.WebApi.UseCases.V1.Transfer.TransferPresenter>());
            return services;
        }
    }
}