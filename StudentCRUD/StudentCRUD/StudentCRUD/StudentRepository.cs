using StudentCRUD.StudentManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCRUD
{
    public static class StudentRepository
    {
        // Using a static list to simulate a database for this demo
        private static List<Student> _students = new List<Student>
        {
            new Student {
                ID = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(2000, 1, 15),
                Email = "john.doe@example.com",
                Course = "Computer Science",
                GPA = 3.8
            },
            new Student {
                ID = 2,
                FirstName = "Jane",
                LastName = "Smith",
                DateOfBirth = new DateTime(2001, 5, 10),
                Email = "jane.smith@example.com",
                Course = "Mathematics",
                GPA = 3.9
            },
            new Student {
                ID = 3,
                FirstName = "Michael",
                LastName = "Johnson",
                DateOfBirth = new DateTime(1999, 8, 22),
                Email = "michael.j@example.com",
                Course = "Physics",
                GPA = 3.5
            }
        };

        // Get all students
        public static List<Student> GetAllStudents()
        {
            return _students;
        }

        // Get a student by ID
        public static Student GetStudentByID(int id)
        {
            return _students.Find(s => s.ID == id);
        }

        // Add a new student
        public static void AddStudent(Student student)
        {
            // Generate a new ID
            int newID = _students.Count > 0 ? _students.Max(s => s.ID) + 1 : 1;
            student.ID = newID;
            _students.Add(student);
        }

        // Update an existing student
        public static void UpdateStudent(Student student)
        {
            int index = _students.FindIndex(s => s.ID == student.ID);
            if (index != -1)
            {
                _students[index] = student;
            }
        }

        // Delete a student
        public static void DeleteStudent(int id)
        {
            _students.RemoveAll(s => s.ID == id);
        }

        // Search students by name (optional enhancement)
        public static List<Student> SearchStudents(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return _students;

            searchTerm = searchTerm.ToLower();
            return _students.Where(s =>
                s.FirstName.ToLower().Contains(searchTerm) ||
                s.LastName.ToLower().Contains(searchTerm) ||
                s.Email.ToLower().Contains(searchTerm)
            ).ToList();
        }

        // Get students by course (optional enhancement)
        public static List<Student> GetStudentsByCourse(string course)
        {
            if (string.IsNullOrEmpty(course))
                return _students;

            return _students.Where(s => s.Course == course).ToList();
        }

        // Get statistics (optional enhancement)
        public static object GetStatistics()
        {
            return new
            {
                TotalStudents = _students.Count,
                AverageGPA = _students.Count > 0 ? _students.Average(s => s.GPA) : 0,
                CourseCounts = _students.GroupBy(s => s.Course)
                                        .Select(g => new { Course = g.Key, Count = g.Count() })
                                        .ToList()
            };
        }
    }
}