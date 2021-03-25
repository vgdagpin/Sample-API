using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestProj.Application;
using TestProj.EmployeeCommandsTests.Common;
using TestProj.Infrastructure;

namespace TestProj.EmployeeCommandsTests
{
    public class TestServiceProvider : IDisposable
    {
        private readonly ServiceProvider serviceProvider;

        public string DatabaseName { get; private set; }

        public static TestServiceProvider InMemoryContext()
        {
            string _dbName = $"db-{Guid.NewGuid().ToString().Substring(0, 8)}";

            return new TestServiceProvider(_dbName);
        }

        private TestServiceProvider(string dbName)
        {
            DatabaseName = dbName;

            ServiceCollection services = new ServiceCollection();

            services.AddApplication();
            services.AddLogging();


            services.AddInfrastructure(null);
            services.AddInfrastructureUseInMemory(DatabaseName);

            serviceProvider = services.BuildServiceProvider();
        }

        public T GetService<T>()
        {
            return serviceProvider.GetService<T>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                var _dbContext = GetService<DbContext>();

                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                }

                serviceProvider.Dispose();

            }
        }
    }
}
