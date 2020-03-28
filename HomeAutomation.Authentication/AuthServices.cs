using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HomeAutomation.Auth
{
    public static class AuthServices
    {
        public static IServiceCollection ConfigureIdentityServer4(this IServiceCollection services, string connectionString, string migrationsAssembly)
        {
            services.AddIdentityServer()
                    .AddOperationalStore(options => options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
                    .AddConfigurationStore(options => options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
                    .AddAspNetIdentity<IdentityUser>();

            return services;
        }
    }
}
