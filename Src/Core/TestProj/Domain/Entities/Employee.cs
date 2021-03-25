using System;
using System.Collections.Generic;
using System.Text;

namespace TestProj.Domain.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        public Gender? Gender { get; set; }
    }
}
