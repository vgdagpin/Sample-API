using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

using TestProj.Domain.Entities;

/*
Do not modify this file! This is auto generated!
Any changes to this file will be gone when template gets generated again.
*/

namespace TestProj.Interfaces
{
	public interface ITestProjDbContext
	{
		#region Entities
		IQueryable<Employee> Employees { get; }
        #endregion
	}
}

