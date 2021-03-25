using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestProj.Infrastructure.Persistence;

namespace TestProj.EmployeeCommandsTests.Common
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureUseInMemory(this IServiceCollection services, string databaseName)
        {
            services.AddDbContext<TestProjDbContext>(opt =>
            {
                opt.UseInMemoryDatabase(databaseName: databaseName);
                opt.ConfigureWarnings(a => a.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            return services;
        }
    }
}
