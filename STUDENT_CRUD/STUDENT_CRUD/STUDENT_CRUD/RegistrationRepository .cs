using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace STUDENT_CRUD
{
    public class RegistrationRepository
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;


        public static List<Course> LoadCourses()
        {
            List<Course> courses = new List<Course>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT CourseID, CourseName FROM Courses";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            courses.Add(new Course
                            {
                                CourseID = reader.GetInt32(0),
                                CourseName = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            return courses;
        }
        public static List<Group> LoadGroups(int courseID)
        {
            List<Group> groups = new List<Group>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT GroupID, GroupName, StudyTime FROM Groups WHERE CourseID = @CourseID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseID", courseID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            groups.Add(new Group
                            {
                                GroupID = reader.GetInt32(0),
                                GroupName = reader.GetString(1),
                                StudyTime = reader.GetString(2)
                            });
                        }
                    }
                }
            }

            return groups;
        }
        public static int GetCourseIDByName(string courseName)
        {
            int courseID = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT CourseID FROM Courses WHERE CourseName = @CourseName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseName", courseName);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        courseID = Convert.ToInt32(result);
                    }
                }
            }

            return courseID;
        }
        public static string GetStudyTime(int groupID)
        {
            string studyTime = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT StudyTime FROM Groups WHERE GroupID = @GroupID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GroupID", groupID);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        studyTime = result.ToString();
                    }
                }
            }

            return studyTime;
        }
        public static int GetCourseCredits(int courseID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Credits FROM Courses WHERE CourseID = @CourseID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseID", courseID);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0; // Return 0 if no credits found
                }
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



        public static bool RegisterCourse(int courseID, int groupID, decimal tuitionFee, out string errorMessage)
        {
            errorMessage = null;
            try
            {

                int userID = GetUserIDFromSession();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"
                INSERT INTO RegisteredCourses (CourseID, GroupID, TuitionFee, user_id)
                VALUES (@CourseID, @GroupID, @TuitionFee, @UserID)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@CourseID", courseID);
                        command.Parameters.AddWithValue("@GroupID", groupID);
                        command.Parameters.AddWithValue("@TuitionFee", tuitionFee);
                        command.Parameters.AddWithValue("@UserID", userID);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            errorMessage = "No rows were affected. Registration failed.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public static DataTable GetRegisteredCourses(int userId)

        {

            DataTable dataTable = new DataTable();

            try
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                  SELECT 
                    C.CourseName, 
                    G.GroupName, 
                    G.StudyTime,
                    R.TuitionFee
                FROM 
                    RegisteredCourses R
                    INNER JOIN Courses C ON R.CourseID = C.CourseID
                    INNER JOIN Groups G ON R.GroupID = G.GroupID
                WHERE 
                    R.user_id = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@UserID", userId);
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);
            }

            return dataTable;
        }
        public static decimal CalculateTotalTuitionFee(int userID)
        {
            decimal totalTuitionFee = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT SUM(TuitionFee) AS TotalTuitionFee
                FROM RegisteredCourses
                WHERE user_id = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@UserID", userID);

                        connection.Open();
                        object result = command.ExecuteScalar();


                        if (result != null && result != DBNull.Value)
                        {
                            totalTuitionFee = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);
            }

            return totalTuitionFee;
        }
        public static int CalculateTotalCredits(int userId)
        {
            int totalCredits = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                   
                    string query = @"
                    SELECT SUM(c.Credits) AS TotalCredits
                    FROM RegisteredCourses rc
                    INNER JOIN Courses c ON rc.CourseId = c.CourseId
                    WHERE rc.user_id = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            totalCredits = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error calculating credits: {ex.Message}");
                throw;
            }

            return totalCredits;
        }
        public static User GetStudentById(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT user_id, username FROM Users WHERE user_id = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserID = Convert.ToInt32(reader["user_id"]),

                                Username = reader["username"].ToString()
                            };
                        }
                    }
                }
            }
            throw new Exception("Student not found");
        }


        public static bool DeleteRegisteredCourse(int courseID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM RegisteredCourses WHERE CourseID = @CourseID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CourseID", courseID);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting course: {ex.Message}");
                return false;
            }
        }

        internal static bool DeleteRegisteredCourse(string courseName)
        {
            throw new NotImplementedException();
        }
    }
}