using EAuction.Order.Domain.Repositories;
using EAuction.Order.Infrastructure.Data;
using EAuction.Order.Infrastructure.Repositories;
using EAuction.Order.Infrastructure.Settings;
using EAuction.Products.Api.Data;
using EAuction.Products.Api.Data.Abstractions;
using EAuction.Products.Api.Repositories;
using EAuction.Products.Api.Repositories.Abstractions;
using EAuction.Products.Api.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace EAuction.Order.Infrastructure.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IBidDatabaseSettings, BidDatabaseSettings>();
            services.AddTransient<IBidContext, BidContext>();
            services.AddTransient<IBidRepository, BidRepository>();
            
            services.AddSingleton<IProductDatabaseSettings, ProductDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ProductDatabaseSettings>>().Value);
            services.AddTransient<IProductContext, ProductContext>();
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}