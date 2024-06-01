/*
Department implements the department service class
*/

using System;
using System.Collections.Generic;

namespace UniversitySystem
{
    public class Department : IDepartmentService
    {
        public string DepartmentName { get; set; }
        public Instructor Head { get; private set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Course> CoursesOffered { get; private set; } = new List<Course>();

        public void SetHead(Instructor instructor)
        {
            Head = instructor;
        }

        public void AddCourse(Course course)
        {
            CoursesOffered.Add(course);
        }
    }
}