using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TasqR;

using TestProj.Domain.Entities;
using TestProj.Interfaces;
using TestProj.Queries.EmployeeQrs;

namespace TestProj.Application.Handlers.Queries.EmployeeQrs
{
    public class GetEmployeesQrHandler : TasqHandlerAsync<GetEmployeesQr, IEnumerable<Employee>>
    {
        private readonly ITestProjDbContext dbContext;

        public GetEmployeesQrHandler(ITestProjDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async override Task<IEnumerable<Employee>> RunAsync(GetEmployeesQr request, CancellationToken cancellationToken = default)
        {
            return await dbContext.Employees.ToListAsync();
        }
    }
}
