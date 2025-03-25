//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace STUDENT_CRUD
//{
//    public partial class StudentList : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                BindStudentData();
//            }

//        }
//        private void BindStudentData()
//        {
//            gvStudents.DataSource = UserRepository.GetAllStudents();
//            gvStudents.DataBind();
//        }
//        protected void btnAddNew_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("StudentForm.aspx");
//        }
//        protected void gvStudents_RowCommand(object sender, GridViewCommandEventArgs e)
//        {

//        }

//    }
//}