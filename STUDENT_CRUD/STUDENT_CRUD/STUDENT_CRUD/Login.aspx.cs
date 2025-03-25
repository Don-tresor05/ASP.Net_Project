using System;
using System.Web.UI;

namespace STUDENT_CRUD
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User loggedInUser = UserRepository.Login(username, password);
            if (loggedInUser != null)
            {
                Session["UserID"] = loggedInUser.UserID;
                Session["Username"] = loggedInUser.Username;
                Session["Role"] = loggedInUser.Role;

                if (loggedInUser.Role == "Admin")
                {
                    Response.Redirect("AdminDashboard.aspx");
                }
                else
                {
                    Response.Redirect("UserDashboard.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}