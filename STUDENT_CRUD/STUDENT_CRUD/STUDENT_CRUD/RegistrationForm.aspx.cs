using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace STUDENT_CRUD
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {

                try
                {
                    if (Request.QueryString["print"] == "true")
                    {
                       
                        LoadCoursesForPrint();

                        
                        AddPrintStyles();

                       
                        RegisterAutoPrintScript();
                    }
                    else
                    {
                        lblGeneratedDate.Text = DateTime.Now.ToString("MM/dd/yyyy");


                        LoadStudentData();


                        LoadRegisteredCourses();
                    }

                    
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Initialization error: {ex.Message.Replace("'", "\\'")}');</script>");
                }
            }

        }
        private void LoadStudentData()
        {
           
            
            int userId = GetUserIDFromSession();
            var student = RegistrationRepository.GetStudentById(userId);

            lblStudentNumber.Text = student.UserID.ToString();
            lblStudentNames.Text = student.Username;

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
        private void LoadRegisteredCourses()
        {
            try
            {
                int userId = GetUserIDFromSession();
                var registeredCourses = RegistrationRepository.GetRegisteredCourses(userId);

                gvRegisteredCourses.DataSource = registeredCourses;
                gvRegisteredCourses.DataBind();

                decimal tuitionFee = RegistrationRepository.CalculateTotalTuitionFee(userId);
                int totalCredits = RegistrationRepository.CalculateTotalCredits(userId);

                decimal registrationFee = 25000;
                decimal totalToPay = tuitionFee + registrationFee;

                lblTotalCredits.Text = totalCredits.ToString();
                lblTuitionFee.Text = tuitionFee.ToString("N0");
                lblTotalToPay.Text = totalToPay.ToString("N0");


            }
            catch (Exception ex)
            {
                
                Response.Write($"<script>alert('Error: {ex.Message.Replace("'", "\\'")}');</script>");
            }
        }
        protected void LoadCoursesForPrint()
        {
            if (Session["RegisteredCoursesForPrint"] is DataTable registeredCourses)
            {
                gvRegisteredCourses.DataSource = registeredCourses;
                gvRegisteredCourses.DataBind();

                
                decimal totalTuition = 0;
                foreach (DataRow row in registeredCourses.Rows)
                {
                    totalTuition += Convert.ToDecimal(row["TuitionFee"]);
                }

                lblTuitionFee.Text = totalTuition.ToString("N0");
                lblTotalToPay.Text = (totalTuition + 25000).ToString("N0"); 
            }
        }
        private void RegisterAutoPrintScript()
        {
            string script = @"
        window.onload = function() {
            setTimeout(function() {
                window.print();
                window.close();
            }, 500);
        };";
            ClientScript.RegisterStartupScript(this.GetType(), "AutoPrint", script, true);
        }
        private void AddPrintStyles()
        {
            
            string css = @"
        <style type='text/css' media='print'>
            .no-print { display: none !important; }
            body { font-size: 12pt; }
            .course-table { width: 100%; border-collapse: collapse; }
            .course-table th, .course-table td { border: 1px solid #000; padding: 4px; }
        </style>";
            LiteralControl styleControl = new LiteralControl(css);
            Page.Header.Controls.Add(styleControl);
        }

    }
    }