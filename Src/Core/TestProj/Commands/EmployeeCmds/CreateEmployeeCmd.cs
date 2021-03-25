using System;
using System.Collections.Generic;
using System.Text;

using TasqR;

using TestProj.Domain.Entities;

namespace TestProj.Commands.EmployeeCmds
{
    public class CreateEmployeeCmd : ITasq<Employee>
    {
        public CreateEmployeeCmd(string firstName, string middleName, string lastName, Gender gender)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Gender = gender;
        }

        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public Gender Gender { get; }
    }
}
