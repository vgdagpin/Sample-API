using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using TasqR;

using TestProj.Commands.EmployeeCmds;
using TestProj.Queries.EmployeeQrs;
using TestProj.WebAPI.ViewModels;

namespace TestProj.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ITasqR tasqR;
        private readonly DbContext baseDbContext;

        public EmployeeController(ITasqR tasqR, DbContext baseDbContext)
        {
            this.tasqR = tasqR;
            this.baseDbContext = baseDbContext;
        }

        [HttpGet]
        public Task<IEnumerable<EmployeeVM>> Get(CancellationToken cancellationToken = default)
        {
            return tasqR.RunAsync(new GetEmployeesQr(), cancellationToken)
                .ContinueWith(r =>
                {
                    // we use mapper here (eg.AutoMapper)
                    return r.Result.Select(a => new EmployeeVM
                    {
                        ID = a.ID,
                        FirstName = a.FirstName,
                        MiddleName = a.MiddleName,
                        LastName = a.LastName,
                        Gender = a.Gender.GetValueOrDefault(),
                        Address = a.Address
                    });
                });
        }

        public async Task<EmployeeVM> Post(EmployeeVM newEmployee, CancellationToken cancellationToken = default)
        {
            var cmd = new CreateEmployeeCmd(newEmployee.FirstName, newEmployee.MiddleName, newEmployee.LastName, newEmployee.Gender);

            var newEmp = await tasqR.RunAsync(cmd, cancellationToken);

            // we can still modify this newEmp before executing SaveChanges

            // because we register the DbContext in DI as an instance of TestProjDbContext in our infrastructure (as Scope lifetime)
            await baseDbContext.SaveChangesAsync();

            return new EmployeeVM
            {
                ID = newEmp.ID,
                FirstName = newEmp.FirstName,
                MiddleName = newEmp.MiddleName,
                LastName = newEmp.LastName,
                Address = newEmp.Address,
                Gender = newEmp.Gender.GetValueOrDefault()
            };
        }
    }
}