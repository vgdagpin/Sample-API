using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

using TasqR;

using TestProj.Application.Common.Extensions;
using TestProj.Commands.EmployeeCmds;
using TestProj.Domain.Entities;
using TestProj.Interfaces;
using TestProj.Queries.EmployeeQrs;

namespace TestProj.EmployeeCommandsTests
{
    [TestClass]
    public class EmployeeUpdateCmdTests
    {
        [TestMethod]
        public void CanUpdateEmployeeAddress()
        {
            using (var services = TestServiceProvider.InMemoryContext())
            {
                #region Arrange
                var dbContext = services.GetService<ITestProjDbContext>();
                var tasqR = services.GetService<ITasqR>();

                Employee employee = new Employee
                {
                    FirstName = "Vince",
                    LastName = "Dagpin",
                    Gender = Gender.Male
                };

                dbContext.Employees.Add(employee);
                ((DbContext)dbContext).SaveChanges();
                #endregion

                #region Act
                tasqR.Run(new UpdateEmployeeAddressCmd(1, "Test Address"));
                ((DbContext)dbContext).SaveChanges();
                #endregion

                #region Assert
                var updatedEmployee = tasqR.Run(new FindEmployeeQr(1));
                var allEmployees = tasqR.Run(new GetEmployeesQr());

                Assert.IsNotNull(updatedEmployee);
                Assert.AreEqual("Test Address", updatedEmployee.Address);
                Assert.AreEqual(1, allEmployees.Count());
                #endregion
            }
        }
    }
}
