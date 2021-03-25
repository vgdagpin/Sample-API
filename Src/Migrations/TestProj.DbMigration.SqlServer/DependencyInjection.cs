using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using System;

using TestProj.Infrastructure.Persistence;
using System.Reflection;

namespace TestProj.DbMigration.SqlServer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureUseSqlServer
            (
                this IServiceCollection services,
                IConfiguration configuration
            )
        {
            services.AddDbContext<TestProjDbContext>((svc, options) =>
            {
                options.UseSqlServer
                (
                    connectionString: configuration.GetConnectionString($"{nameof(TestProjDbContext)}_MSSQLConStr"),
                    sqlServerOptionsAction: opt =>
                    {
                        opt.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                        opt.MigrationsHistoryTable("MigrationHistory", "adm");
                        }
                );
            });

            return services;
        }
    }
}
