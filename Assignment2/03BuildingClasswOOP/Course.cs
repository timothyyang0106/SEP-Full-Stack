/*
Course implements the course interface.
*/

using System;
using System.Collections.Generic;

namespace UniversitySystem
{
    public class Course : ICourseService
    {
        public string CourseName { get; set; }
        public List<Student> EnrolledStudents { get; private set; } = new List<Student>();

        public void AddStudent(Student student)
        {
            if (!EnrolledStudents.Contains(student))
            {
                EnrolledStudents.Add(student);
            }
        }

        public void AssignGrade(Student student, char grade)
        {
            if (EnrolledStudents.Contains(student))
            {
                student.AssignGrade(this, grade);
            }
        }
    }
}