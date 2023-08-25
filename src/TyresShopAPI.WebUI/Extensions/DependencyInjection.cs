﻿using TyresShopAPI.Application.Interfaces;
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
            services.AddScoped<ICartService, CartService>();

            return services;
        }

    }
}