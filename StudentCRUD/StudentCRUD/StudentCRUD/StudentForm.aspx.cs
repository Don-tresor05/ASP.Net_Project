using StudentCRUD.StudentManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace StudentCRUD
{
    public partial class StudentForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set the validation date comparison
                cvDateOfBirth.ValueToCompare = DateTime.Now.ToString("yyyy-MM-dd");

                // Check if we're editing an existing student
                if (Request.QueryString["id"] != null)
                {
                    int studentID = Convert.ToInt32(Request.QueryString["id"]);
                    LoadStudentData(studentID);
                    ltlTitle.Text = "Edit Student";
                }
                else
                {
                    ltlTitle.Text = "Add New Student";
                }
            }
        }

        private void LoadStudentData(int studentID)
        {
            Student student = StudentRepository.GetStudentByID(studentID);
            if (student != null)
            {
                hfStudentID.Value = student.ID.ToString();
                txtFirstName.Text = student.FirstName;
                txtLastName.Text = student.LastName;
                txtDateOfBirth.Text = student.DateOfBirth.ToString("yyyy-MM-dd");
                txtEmail.Text = student.Email;
                ddlCourse.SelectedValue = student.Course;
                txtGPA.Text = student.GPA.ToString("F1");
            }
            else
            {
                // Student not found, redirect to list
                Response.Redirect("StudentList.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    // Create or update a student object
                    Student student = new Student
                    {
                        FirstName = txtFirstName.Text.Trim(),
                        LastName = txtLastName.Text.Trim(),
                        DateOfBirth = DateTime.Parse(txtDateOfBirth.Text),
                        Email = txtEmail.Text.Trim(),
                        Course = ddlCourse.SelectedValue,
                        GPA = Convert.ToDouble(txtGPA.Text)
                    };

                    // Check if we're updating an existing student
                    if (!string.IsNullOrEmpty(hfStudentID.Value))
                    {
                        student.ID = Convert.ToInt32(hfStudentID.Value);
                        StudentRepository.UpdateStudent(student);
                    }
                    else
                    {
                        StudentRepository.AddStudent(student);
                    }

                    // Redirect back to the student list
                    Response.Redirect("StudentList.aspx");
                }
                catch (Exception ex)
                {
                    // Handle any errors
                    ClientScript.RegisterStartupScript(this.GetType(), "saveError",
                        $"alert('Error saving student: {ex.Message}');", true);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentList.aspx");
        }
    }
}