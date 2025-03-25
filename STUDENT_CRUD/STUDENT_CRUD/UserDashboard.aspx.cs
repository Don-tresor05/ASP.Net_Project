using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STUDENT_CRUD
{
    public partial class UserDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ddlCourseName.DataSource = RegistrationRepository.LoadCourses();
                ddlCourseName.DataTextField = "CourseName"; 
                ddlCourseName.DataValueField = "CourseID"; 
                ddlCourseName.DataBind();
                LoadRegisteredCourses();
            }
        }
        //private int GetUserIDFromSession()
        //{
        //    if (Session["UserID"] != null)
        //    {
        //        return Convert.ToInt32(Session["UserID"]);
        //    }
        //    else
        //    {
                
        //        Response.Redirect("~/Login.aspx");
        //        return 0; 
        //    }
        //}
        private void LoadRegisteredCourses()
        {
            try
            {
                
                
                int userId=GetUserIDFromSession();
                
                DataTable registeredCourses = RegistrationRepository.GetRegisteredCourses(userId);

                gvRegisteredCourses.DataSource = registeredCourses;
                gvRegisteredCourses.DataBind();

               
                if (registeredCourses.Rows.Count == 0)
                {
                    lblMessage.Text = "No courses found for the logged-in user.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
               
                lblMessage.Text = "An error occurred: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void ddlCourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int courseID = Convert.ToInt32(ddlCourseName.SelectedValue);

            
            ddlGroupCourse.DataSource = RegistrationRepository.LoadGroups(courseID);
            ddlGroupCourse.DataTextField = "GroupName"; 
            ddlGroupCourse.DataValueField = "GroupID"; 
            ddlGroupCourse.DataBind();
        }
        protected void ddlGroupCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int groupID = Convert.ToInt32(ddlGroupCourse.SelectedValue);
            string studyTime = RegistrationRepository.GetStudyTime(groupID);
            txtStudyTime.Text = studyTime;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                
                int courseID = Convert.ToInt32(ddlCourseName.SelectedValue);
                int groupID = Convert.ToInt32(ddlGroupCourse.SelectedValue);
                string studyTime = txtStudyTime.Text;
                decimal costPerCredit = 18000;

                int totalCredits = RegistrationRepository.GetCourseCredits(courseID);
                decimal tuitionFee = totalCredits * costPerCredit;


                string errorMessage;
                bool isRegistered = RegistrationRepository.RegisterCourse(courseID, groupID, tuitionFee, out errorMessage);
                if (isRegistered)
                {
                    
                    lblMessage.Text = "Course registered successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                   
                    lblMessage.Text = "Registration failed. Please try again." + errorMessage; ;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                
                lblMessage.Text = "An error occurred: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private decimal totalTuitionFee = 0;

        protected void gvRegisteredCourses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                decimal tuitionFee = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TuitionFee"));

               
                totalTuitionFee += tuitionFee;
            }

           
            if (e.Row.RowType == DataControlRowType.Footer)
            {
               
                e.Row.Cells[3].Text = totalTuitionFee.ToString("N0");
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right; 
                e.Row.Cells[3].Font.Bold = true;
                e.Row.Cells[3].Font.Size = 15;
            }
        }
        private static int GetUserIDFromSession()
        {
            if (HttpContext.Current.Session["UserID"] != null)
            {
                return Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            }
            else
            {
                throw new InvalidOperationException("UserID not found in session. User may not be logged in.");
            }
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                
                int userId = GetUserIDFromSession();
                var registeredCourses = RegistrationRepository.GetRegisteredCourses(userId);
                Session["RegisteredCoursesForPrint"] = registeredCourses;

                
                var student = RegistrationRepository.GetStudentById(userId);
                Session["StudentInfoForPrint"] = student;

                
                string url = "RegistrationForm.aspx?print=true";
                string script = $"window.open('{url}', '_blank');";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", script, true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    $"alert('Error preparing print: {ex.Message.Replace("'", "\\'")}');", true);
            }
        }
        protected void gvRegisteredCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected row
            GridViewRow row = gvRegisteredCourses.SelectedRow;

            // Populate fields
            ddlCourseName.Text = row.Cells[1].Text;  
            ddlGroupCourse.Text = row.Cells[2].Text;      
            txtStudyTime.Text = row.Cells[3].Text;   

            
            ViewState["SelectedCourseID"] = gvRegisteredCourses.DataKeys[row.RowIndex].Value.ToString();
        }
    }
}