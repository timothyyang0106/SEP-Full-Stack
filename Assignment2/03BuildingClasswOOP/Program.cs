/* C# Assignment 02
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 29th, 2024
*/

/*
Designing and Building Classes using object-oriented principles
1. Write a program that that demonstrates use of four basic principles of
object-oriented programming /Abstraction/, /Encapsulation/, /Inheritance/ and
/Polymorphism/.
2. Use /Abstraction/ to define different classes for each person type such as Student
and Instructor. These classes should have behavior for that type of person.
3. Use /Encapsulation/ to keep many details private in each class.
4. Use /Inheritance/ by leveraging the implementation already created in the Person
class to save code in Student and Instructor classes.
5. Use /Polymorphism/ to create virtual methods that derived classes could override to
create specific behavior such as salary calculations.
6. Make sure to create appropriate /interfaces/ such as ICourseService, IStudentService,
IInstructorService, IDepartmentService, IPersonService, IPersonService (should have
person specific methods). IStudentService, IInstructorService should inherit from
IPersonService.
Person
Calculate Age of the Person
Calculate the Salary of the person, Use decimal for salary
Salary cannot be negative number
Can have multiple Addresses, should have method to get addresses
Instructor
Belongs to one Department and he can be Head of the Department
Instructor will have added bonus salary based on his experience, calculate his
years of experience based on Join Date
Student
Can take multiple courses
Calculate student GPA based on grades for courses
Each course will have grade from A to F
Course
Will have list of enrolled students
Department
Will have one Instructor as head
Will have Budget for school year (start and end Date Time)
Will offer list of courses
*/

using System;

namespace UniversitySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create some students and instructors
            Student student1 = new Student("Alice", new DateTime(2000, 5, 15), 0);
            Student student2 = new Student("Bob", new DateTime(1999, 7, 20), 0);
            Instructor instructor1 = new Instructor("Dr. Smith", new DateTime(1970, 3, 10), 50000, new DateTime(2000, 6, 1));
            Instructor instructor2 = new Instructor("Prof. Johnson", new DateTime(1965, 10, 5), 55000, new DateTime(1995, 8, 1));

            // Create a department
            Department csDepartment = new Department
            {
                DepartmentName = "Computer Science",
                Budget = 1000000,
                StartDate = new DateTime(2024, 1, 1),
                EndDate = new DateTime(2024, 12, 31)
            };

            // Assign head of department
            csDepartment.SetHead(instructor1);

            // Create courses
            Course course1 = new Course { CourseName = "Programming 101" };
            Course course2 = new Course { CourseName = "Data Structures" };

            // Add courses to department
            csDepartment.AddCourse(course1);
            csDepartment.AddCourse(course2);

            // Enroll students in courses
            course1.AddStudent(student1);
            course1.AddStudent(student2);
            course2.AddStudent(student1);

            // Assign grades
            course1.AssignGrade(student1, 'A');
            course1.AssignGrade(student2, 'B');
            course2.AssignGrade(student1, 'A');

            // Display results
            // Console.WriteLine($"{student1.Name}'s GPA: {student1.CalculateGPA()}");
            // Console.WriteLine($"{student2.Name}'s GPA: {student2.CalculateGPA()}");

            Console.WriteLine($"{instructor1.Name}'s Salary: {instructor1.CalculateSalary()}");
            Console.WriteLine($"{instructor2.Name}'s Salary: {instructor2.CalculateSalary()}");

            Console.WriteLine($"{csDepartment.DepartmentName} Department Head: {csDepartment.Head.Name}");
            
            // Display additional information
            Console.WriteLine($"\n--- Additional Information ---");

            // Console.WriteLine($"{student1.Name}'s enrolled courses: {string.Join(", ", student1.GetEnrolledCourses().Select(c => c.CourseName))}");
            // Console.WriteLine($"{student2.Name}'s enrolled courses: {string.Join(", ", student2.GetEnrolledCourses().Select(c => c.CourseName))}");

            Console.WriteLine($"{instructor1.Name}'s years of experience: {instructor1.CalculateYearsOfExperience()}");
            Console.WriteLine($"{instructor2.Name}'s years of experience: {instructor2.CalculateYearsOfExperience()}");

            Console.WriteLine($"{csDepartment.DepartmentName} department courses offered: {string.Join(", ", csDepartment.CoursesOffered.Select(c => c.CourseName))}");
            Console.WriteLine($"Department budget: ${csDepartment.Budget}");
        }
    }
}
