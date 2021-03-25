using System;
using System.Collections.Generic;
using System.Text;

using TasqR;

using TestProj.Application.Common.Extensions;
using TestProj.Commands.EmployeeCmds;
using TestProj.Domain.Entities;
using TestProj.Interfaces;

namespace TestProj.Application.Handlers.Commands.EmployeeCmds
{
    public class CreateEmployeeCmdHandler : TasqHandler<CreateEmployeeCmd, Employee>
    {
        private readonly ITestProjDbContext dbContext;

        public CreateEmployeeCmdHandler(ITestProjDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public override Employee Run(CreateEmployeeCmd request)
        {
            var newEmployee = new Employee
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,                
                Gender = request.Gender
            };

            dbContext.Employees.Add(newEmployee);

            // we do not execute savechanges here because we might be doing some other stuff in
            // another command/controller/ or somewhere else.
            // execute only savechanges after all is setup so that there will be 
            // only 1 transaction in context

            return newEmployee;
        }
    }
}