using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;

using TestProj.Infrastructure.Persistence;
using TestProj.Interfaces;

namespace TestProj.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITestProjDbContext>(provider => provider.GetService<TestProjDbContext>());
            services.AddScoped<DbContext>(provider => provider.GetService<TestProjDbContext>());

            return services;
        }
    }
}
