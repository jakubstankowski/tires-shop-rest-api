using TyresShopAPI.Application.Interfaces;
using TyresShopAPI.Application.Services;

namespace TyresShopAPI.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ITyresService, TyresService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IProducerService, ProducerService>();
            services.AddScoped<ICustomerCartService, CustomerCartService>();
            services.AddScoped<IDeliveryMethodService, DeliveryMethodService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }

    }
}
