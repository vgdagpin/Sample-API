using System;
using System.Collections.Generic;
using System.Text;

using TasqR;

using TestProj.Domain.Entities;

namespace TestProj.Commands.EmployeeCmds
{
    public class UpdateEmployeeAddressCmd : ITasq<Employee>
    {
        public UpdateEmployeeAddressCmd(int employeeID, string address)
        {
            EmployeeID = employeeID;
            Address = address;
        }

        public int EmployeeID { get; }
        public string Address { get; }
    }
}
