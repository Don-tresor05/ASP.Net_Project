using System;
using System.Data.SqlClient;

namespace STUDENT_CRUD
{
    public partial class EditCourse : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        private int courseID;

        protected void Page_Load(object sender, EventArgs e)
        {
            courseID = Convert.ToInt32(Request.QueryString["CourseID"]);
            if (!IsPostBack)
            {
                LoadCourseDetails(courseID);
            }
        }

        private void LoadCourseDetails(int courseID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT CourseName, GroupName, StudyTime, TuitionFee FROM RegisteredCourses WHERE CourseID = @CourseID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseID", courseID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtCourseName.Text = reader["CourseName"].ToString();
                            txtGroupName.Text = reader["GroupName"].ToString();
                            txtStudyTime.Text = reader["StudyTime"].ToString();
                            txtTuitionFee.Text = reader["TuitionFee"].ToString();
                        }
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE RegisteredCourses SET CourseName = @CourseName, GroupName = @GroupName, StudyTime = @StudyTime, TuitionFee = @TuitionFee WHERE CourseID = @CourseID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseName", txtCourseName.Text.Trim());
                    cmd.Parameters.AddWithValue("@GroupName", txtGroupName.Text.Trim());
                    cmd.Parameters.AddWithValue("@StudyTime", txtStudyTime.Text.Trim());
                    cmd.Parameters.AddWithValue("@TuitionFee", Convert.ToDecimal(txtTuitionFee.Text.Trim()));
                    cmd.Parameters.AddWithValue("@CourseID", courseID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            Response.Redirect("UserDashboard.aspx");
        }
    }
}