
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCRUD
{
    public class StudentRepository
    {
        private static List<Student> _students = new List<Student>
        {
            new Student{ ID=1, FirstName="Eric",LastName="Gwiza",DateOfBirth=new DateTime(2000,1,15),Email="eric@auca.ac.rw",Course="Dot Net",GPA=4.0},
            new Student{ ID=2, FirstName="Eric",LastName="Gwiza",DateOfBirth=new DateTime(2000,1,15),Email="eric@auca.ac.rw",Course="Dot Net",GPA=4.0},
            new Student{ ID=3, FirstName="Gerard",LastName="Gwiza",DateOfBirth=new DateTime(2000,1,15),Email="eric@auca.ac.rw",Course="Dot Net",GPA=4.0},
            new Student{ ID=4, FirstName="Eric",LastName="Gwiza",DateOfBirth=new DateTime(2000,1,15),Email="eric@auca.ac.rw",Course="Dot Net",GPA=4.0},
        };
        public static List<Student> GetAllStudents()
        {
            return _students;
        }
        public static Student GetStudentByID(int id)
        {
            return _students.Find(s=>s.ID == id);
        }
        public static void AddStudent(Student student)
        {
            //Codes to get the last ID and increment by 1
            int newId = _students.Count > 0 ? _students.Max(s => s.ID) + 1 : 1;
            student.ID = newId;
            //Now insert Data
            _students.Add(student);
        }
        //Update Student
        public static void UpdateStudent(Student student)
        {
            int index = _students.FindIndex(s=>s.ID == student.ID);
            if(index != -1)
            {
                _students[index]=student;
            }
            
        }
        //Delete Student 
        public static void DeleteStudent(int id)
        {
            _students.RemoveAll(s=>s.ID == id);
        }
    }
}