/*
Student is a derived class from both a Person Abstract class and implements the IStudentService interface
*/

using System;

namespace UniversitySystem
{
    public class Student : Person, IStudentService
    {
        public DateTime JoinDate { get; set; }
        private Dictionary<Course, char> courseGrades = new Dictionary<Course, char>();

        public Student(string name, DateTime birthDate, decimal salary)
            : base(name, birthDate, salary)
        {
        }

        public void EnrollInCourse(Course course)
        {
            if (!courseGrades.ContainsKey(course))
            {
                courseGrades[course] = 'N';  // Assuming 'N' for not graded initially.
                course.AddStudent(this);  // Ensuring the course knows this student is enrolled.
            }
        }

        public void AssignGrade(Course course, char grade)
        {
            if (courseGrades.ContainsKey(course))
            {
                courseGrades[course] = grade;
            }
        }
        public decimal CalculateBonusSalary()
        {
            int yearsOfExperience = DateTime.Today.Year - JoinDate.Year;
            return Salary + (yearsOfExperience * 1000); // example bonus calculation
        }
        
        public override decimal CalculateSalary()
        {
            return CalculateBonusSalary();
        }
        public double CalculateGPA()
        {
            if (courseGrades.Count == 0) return 0.0;
            double totalPoints = courseGrades.Values.Where(grade => grade != 'N').Select(GradeToPoint).Sum();
            int countGrades = courseGrades.Count(grade => grade.Value != 'N');
            return countGrades > 0 ? totalPoints / countGrades : 0.0;
        }

        public List<Course> GetEnrolledCourses()
        {
            return courseGrades.Keys.ToList();
        }

        private double GradeToPoint(char grade)
        {
            return grade switch
            {
                'A' => 4.0,
                'B' => 3.0,
                'C' => 2.0,
                'D' => 1.0,
                'F' => 0.0,
                _ => 0.0
            };
        }
    }

}