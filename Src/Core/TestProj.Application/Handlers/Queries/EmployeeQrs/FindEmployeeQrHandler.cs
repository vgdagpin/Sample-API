using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TasqR;

using TestProj.Domain.Entities;
using TestProj.Interfaces;
using TestProj.Queries.EmployeeQrs;

namespace TestProj.Application.Handlers.Queries.EmployeeQrs
{
    public class FindEmployeeQrHandler : TasqHandler<FindEmployeeQr, Employee>
    {
        private readonly ITestProjDbContext dbContext;

        public FindEmployeeQrHandler(ITestProjDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public override Employee Run(FindEmployeeQr request)
        {
            return dbContext.Employees.SingleOrDefault(a => a.ID == request.EmployeeID);
        }
    }
}
