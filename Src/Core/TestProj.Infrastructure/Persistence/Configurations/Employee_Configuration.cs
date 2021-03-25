using System;
using System.Collections.Generic;
using System.Text;

using TestProj.Domain.Entities;

namespace TestProj.Infrastructure.Persistence.Configurations
{
    public partial class Employee_Configuration
    {
        protected override void ConfigureProperty(BasePropertyBuilder<Employee> builder)
        {
            builder.Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(StringLengthConstants.Names);

            builder.Property(a => a.MiddleName)
                .HasMaxLength(StringLengthConstants.Names);

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(StringLengthConstants.Names);

            builder.Property(a => a.Address)
                .HasMaxLength(StringLengthConstants.Address);

            builder.Property(a => a.Gender)
                .HasConversion<string>()
                .HasMaxLength(StringLengthConstants.Enums);
        }

        protected override void SeedData(BaseSeeder<Employee> builder)
        {
            builder.HasData(new Employee
            {
                ID = 1,
                FirstName = "Vincent",
                MiddleName = "Gubantes",
                LastName = "Dagpin",
                Gender = Gender.Male,
                Address = "LNC"
            });
        }
    }
}