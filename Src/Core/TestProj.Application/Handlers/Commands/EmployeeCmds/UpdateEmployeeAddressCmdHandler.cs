using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TasqR;

using TestProj.Commands.EmployeeCmds;
using TestProj.Domain.Entities;
using TestProj.Interfaces;

namespace TestProj.Application.Handlers.Commands.EmployeeCmds
{
    public class UpdateEmployeeAddressCmdHandler : TasqHandler<UpdateEmployeeAddressCmd, Employee>
    {
        private readonly ITestProjDbContext dbContext;

        public UpdateEmployeeAddressCmdHandler(ITestProjDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public override Employee Run(UpdateEmployeeAddressCmd request)
        {
            var emp = dbContext.Employees.SingleOrDefault(a => a.ID == request.EmployeeID);

            if (emp != null)
            {
                emp.Address = request.Address;
            }

            return emp;
        }
    }
}
