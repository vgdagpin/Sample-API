using System;
using System.Collections.Generic;
using System.Text;

using TasqR;

using TestProj.Domain.Entities;

namespace TestProj.Queries.EmployeeQrs
{
    public class GetEmployeesQr : ITasq<IEnumerable<Employee>>
    {
        public GetEmployeesQr()
        {

        }

        public GetEmployeesQr(string filter)
        {
            Filter = filter;
        }

        public string Filter { get; }
    }
}
