/* 
This file is where all the interfaces are.
Including PersonService, CourseService, and DepartmentService
*/

using System;
using System.Collections.Generic;

namespace UniversitySystem
{
    public interface IPersonService
    {
        int CalculateAge(DateTime birthDate);
        decimal CalculateSalary();
        List<string> GetAddresses();
    }

    public interface IStudentService : IPersonService
    {
        double CalculateGPA();
        void EnrollInCourse(Course course);
    }

    public interface IInstructorService : IPersonService
    {
        decimal CalculateBonusSalary();
        void AssignDepartment(Department department);
    }

    public interface ICourseService
    {
        void AddStudent(Student student);
        void AssignGrade(Student student, char grade);
    }

    public interface IDepartmentService
    {
        void SetHead(Instructor instructor);
        void AddCourse(Course course);
    }
}
