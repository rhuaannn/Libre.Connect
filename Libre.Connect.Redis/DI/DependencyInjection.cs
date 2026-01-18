using Libre.Connect.Redis.Interface;
using Libre.Connect.Redis.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Libre.Connect.Redis.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddRedisInfra(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Redis");
            
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = connectionString;
                options.InstanceName = "LibreConnect";
            });

            services.AddSingleton<ICaching, Caching>();
            return services;
        }
    }
