//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace STUDENT_CRUD
//{
//    public partial class StudentForm : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                rvDateOfBirth.MaximumValue = DateTime.Now.ToString("yyyy-MM-dd");
//            }
//        }
//        private void LoadStudentData(int studentId)
//        {
//            Student student = StudentRepository.GetStudentByID(studentId);
//            if (studentId != null)
//            {
//                hfStudentID.Value = student.ID.ToString();
//                txtFirstName.Text = student.FirstName.ToString();
//                txtLastName.Text = student.LastName.ToString();
//                txtDateOfBirth.Text = student.DateOfBirth.ToString();
//                txtEmail.Text = student.Email.ToString();
//                ddlCourse.SelectedValue = student.Course.ToString();
//                txtGPA.Text = student.GPA.ToString();
//            }
//        }

//        protected void btnSave_Click(object sender, EventArgs e)
//        {
//            Student student = new Student
//            {
//               FirstName=txtFirstName.Text,
//               LastName=txtFirstName.Text,
//               DateOfBirth=DateTime.Parse(txtDateOfBirth.Text),
//               Email=txtEmail.Text,
//               Course=ddlCourse.SelectedValue,
//               GPA=Convert.ToDouble(txtGPA.Text)

//            };
//            StudentRepository.AddStudent(student);
//            Response.Redirect("StudentList.aspx");
//        }

//        //protected void btnCancel_Click(object sender, EventArgs e)
//        {

//        }
//    }
//}