using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using System;
using System.IO;

using TestProj.Infrastructure.Persistence;
using System.Reflection;

namespace TestProj.DbMigration.SQLite
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureUseSqlite
            (
                this IServiceCollection services
            )
        {
            string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (!Directory.Exists(appDataDirectory))
            {
                Directory.CreateDirectory(appDataDirectory);
            }

            string fileName = Path.Combine(appDataDirectory, $"TestProjDb_SQLite.db3");

            services.AddDbContext<TestProjDbContext>((svc, options) =>
            {
                options.UseSqlite
                (
                    connectionString: $"Filename={fileName}",
                    sqliteOptionsAction: opt =>
                    {
                        opt.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                    }
                );
            });

            return services;
        }
    }
}
