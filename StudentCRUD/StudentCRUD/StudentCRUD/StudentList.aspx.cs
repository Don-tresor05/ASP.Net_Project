using StudentCRUD.StudentManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentCRUD
{
    public partial class StudentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStudentData();
            }
        }

        private void BindStudentData()
        {
            List<Student> students;

            // Check if we have a search term in the session
            if (Session["SearchTerm"] != null && !string.IsNullOrEmpty(Session["SearchTerm"].ToString()))
            {
                string searchTerm = Session["SearchTerm"].ToString();
                txtSearch.Text = searchTerm;
                students = StudentRepository.SearchStudents(searchTerm);
            }
            else
            {
                students = StudentRepository.GetAllStudents();
            }

            gvStudents.DataSource = students;
            gvStudents.DataBind();

            // Show/hide no records panel
            pnlNoRecords.Visible = (students.Count == 0);
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentForm.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            Session["SearchTerm"] = searchTerm;
            BindStudentData();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            Session["SearchTerm"] = null;
            BindStudentData();
        }

        protected void gvStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int studentID = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case "ViewStudent":
                    Response.Redirect($"StudentDetails.aspx?id={studentID}");
                    break;

                case "EditStudent":
                    Response.Redirect($"StudentForm.aspx?id={studentID}");
                    break;

                case "DeleteStudent":
                    StudentRepository.DeleteStudent(studentID);
                    BindStudentData();

                    // Show success message
                    ClientScript.RegisterStartupScript(this.GetType(), "deleteSuccess",
                        "alert('Student deleted successfully.');", true);
                    break;
            }
        }
    }
}