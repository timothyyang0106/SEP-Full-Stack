/*
Abstract Person class for each person type such as student and instructor
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversitySystem
{
    public abstract class Person : IPersonService
    {
        private List<string> addresses = new List<string>();

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }

        public Person(string name, DateTime birthDate, decimal salary)
        {
            Name = name;
            BirthDate = birthDate;
            Salary = salary >= 0 ? salary : throw new ArgumentException("Salary cannot be negative");
        }

        public int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        public abstract decimal CalculateSalary();

        public void AddAddress(string address)
        {
            addresses.Add(address);
        }

        public List<string> GetAddresses()
        {
            return addresses;
        }
    }
}
