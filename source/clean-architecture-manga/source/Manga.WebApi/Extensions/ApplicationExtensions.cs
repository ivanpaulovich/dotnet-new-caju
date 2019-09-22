namespace Manga.WebApi.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
#if (CloseAccount)
            services.AddScoped<Manga.Application.Boundaries.CloseAccount.IUseCase, Manga.Application.UseCases.CloseAccount>();
#endif
#if (Deposit)
            services.AddScoped<Manga.Application.Boundaries.Deposit.IUseCase, Manga.Application.UseCases.Deposit>();
#endif
#if (GetAccountDetails)
            services.AddScoped<Manga.Application.Boundaries.GetAccountDetails.IUseCase, Manga.Application.UseCases.GetAccountDetails>();
#endif
#if (GetCustomerDetails)
            services.AddScoped<Manga.Application.Boundaries.GetCustomerDetails.IUseCase, Manga.Application.UseCases.GetCustomerDetails>();
#endif
#if (GetCustomerDetails)
            services.AddScoped<Manga.Application.Boundaries.Register.IUseCase, Manga.Application.UseCases.Register>();
#endif
#if (Withdraw)
            services.AddScoped<Manga.Application.Boundaries.Withdraw.IUseCase, Manga.Application.UseCases.Withdraw>();
#endif
#if (Transfer)
            services.AddScoped<Manga.Application.Boundaries.Transfer.IUseCase, Manga.Application.UseCases.Transfer>();
#endif
            return services;
        }
    }
}