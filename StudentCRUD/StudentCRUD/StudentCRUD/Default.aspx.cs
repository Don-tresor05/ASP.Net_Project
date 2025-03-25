using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentCRUD
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page load event - no specific actions needed for the home page
        }

        protected void btnGetStarted_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentList.aspx");
        }

        protected void btnStudents_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentList.aspx");
        }

        protected void btnCourses_Click(object sender, EventArgs e)
        {
            // For demonstration purposes, we can show an alert since we don't have a Courses page yet
            ClientScript.RegisterStartupScript(this.GetType(), "courseAlert",
                "alert('Course management will be implemented in a future update.');", true);
        }

        protected void btnStats_Click(object sender, EventArgs e)
        {
            // For demonstration purposes, we can show an alert since we don't have a Statistics page yet
            ClientScript.RegisterStartupScript(this.GetType(), "statsAlert",
                "alert('Statistics functionality will be implemented in a future update.');", true);
        }
    }
}
