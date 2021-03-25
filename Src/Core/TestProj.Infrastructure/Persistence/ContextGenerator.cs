using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using TestProj.Interfaces;
using TestProj.Domain.Entities;

/*
Do not modify this file! This is auto generated!
Any changes to this file will be gone when template gets generated again.
*/

namespace TestProj.Infrastructure.Persistence
{
	public partial class TestProjDbContext : DbContext, ITestProjDbContext
	{
		#region Entities
		private DbSet<Employee> db_Employees { get; set; }
		public IQueryable<Employee> Employees 
		{ 
			get { return db_Employees; }
			private set { db_Employees = (DbSet<Employee>)value; }
		}
        #endregion

		public TestProjDbContext(DbContextOptions<TestProjDbContext> dbContextOpt) : base(dbContextOpt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
	}
}

namespace TestProj.Infrastructure.Persistence.Configurations
{
	public partial class Employee_Configuration : BaseConfiguration<Employee> { }
}
