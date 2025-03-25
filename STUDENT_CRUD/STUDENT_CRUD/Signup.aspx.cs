using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace STUDENT_CRUD
{
    public partial class Signup : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtRegUsername.Text;
            string pwd = txtRegPassword.Text;
            string role = ddlRole.SelectedValue;
            string email = txtRegEmail.Text;


            bool isSignupSuccessful = UserRepository.Signup(username, pwd, role, email);
            if (isSignupSuccessful)
            {
                lblMessage.Text = "Signup successful!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Signup failed. Username or email may already exist.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}