namespace MyFull.WebApi.Extensions
{
    using MyFull.WebApi.Filters;
    using Microsoft.Extensions.DependencyInjection;

    public static class BusinessExceptionExtensions
    {
        public static IServiceCollection AddBusinessExceptionFilter(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(BusinessExceptionFilter));
            });

            return services;
        }
    }
}
