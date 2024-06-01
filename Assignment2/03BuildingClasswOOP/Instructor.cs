/*
Instructor is a derived class from both a Person Abstract class and implements the IInstructorService interface
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversitySystem
{
    public class Instructor : Person, IInstructorService
    {
        public DateTime JoinDate { get; set; }
        public Department Department { get; set; }

        public Instructor(string name, DateTime birthDate, decimal salary, DateTime joinDate)
            : base(name, birthDate, salary)
        {
            JoinDate = joinDate;
        }

        public decimal CalculateBonusSalary()
        {
            int yearsOfExperience = DateTime.Today.Year - JoinDate.Year;
            return Salary + (yearsOfExperience * 1000); // example bonus calculation
        }

        public void AssignDepartment(Department department)
        {
            Department = department;
        }

        public override decimal CalculateSalary()
        {
            return CalculateBonusSalary();
        }

        public int CalculateYearsOfExperience()
        {
            return DateTime.Today.Year - JoinDate.Year;
        }
    }
}