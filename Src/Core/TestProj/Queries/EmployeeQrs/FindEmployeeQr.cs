using System;
using System.Collections.Generic;
using System.Text;

using TasqR;

using TestProj.Domain.Entities;

namespace TestProj.Queries.EmployeeQrs
{
    public class FindEmployeeQr : ITasq<Employee>
    {
        public FindEmployeeQr(int employeeID)
        {
            EmployeeID = employeeID;
        }

        public int EmployeeID { get; }
    }
}
