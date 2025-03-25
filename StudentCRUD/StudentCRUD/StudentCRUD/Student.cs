using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCRUD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    namespace StudentManagementSystem
    {
        public class Student
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Email { get; set; }
            public string Course { get; set; }
            public double GPA { get; set; }

            public string FullName
            {
                get { return FirstName + " " + LastName; }
            }

            public int Age
            {
                get { return DateTime.Now.Year - DateOfBirth.Year; }
            }
        }
    }
}