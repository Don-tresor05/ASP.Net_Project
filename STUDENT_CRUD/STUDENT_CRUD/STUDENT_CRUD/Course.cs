using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STUDENT_CRUD
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public decimal CostPerCredit { get; set; }
    }
}