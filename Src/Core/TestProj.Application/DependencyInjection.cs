using Microsoft.Extensions.DependencyInjection;

using System;
using System.Reflection;

using TasqR;

namespace TestProj.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTasqR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
