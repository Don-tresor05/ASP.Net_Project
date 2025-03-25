using StudentCRUD.StudentManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentCRUD
{
    public partial class StudentDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int studentID = Convert.ToInt32(Request.QueryString["id"]);
                    LoadStudentDetails(studentID);
                }
                else
                {
                    Response.Redirect("StudentList.aspx");
                }
            }
        }

        private void LoadStudentDetails(int studentID)
        {
            Student student = StudentRepository.GetStudentByID(studentID);
            if (student != null)
            {
                hfStudentID.Value = student.ID.ToString();
                ltlStudentName.Text = student.FullName;
                ltlID.Text = student.ID.ToString();
                ltlFirstName.Text = student.FirstName;
                ltlLastName.Text = student.LastName;
                ltlDateOfBirth.Text = student.DateOfBirth.ToShortDateString();
                ltlAge.Text = student.Age.ToString();
                ltlEmail.Text = student.Email;
                ltlCourse.Text = student.Course;
                ltlGPA.Text = string.Format("{0:F1}", student.GPA);
            }
            else
            {
                // Student not found, redirect to list
                Response.Redirect("StudentList.aspx");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect($"StudentForm.aspx?id={hfStudentID.Value}");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int studentID = Convert.ToInt32(hfStudentID.Value);
            StudentRepository.DeleteStudent(studentID);
            Response.Redirect("StudentList.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentList.aspx");
        }
    }
}