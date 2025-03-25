using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace STUDENT_CRUD
{
    public class UserRepository
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

        // Signup method with hashed password
        public static bool Signup(string username, string pwd, string role, string email)
        {
            try
            {
                string hashedPassword = HashPassword(pwd); // Hash the password

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT_USER"; // Stored procedure name
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", hashedPassword); // Save hashed password
                        command.Parameters.AddWithValue("@role", role);
                        command.Parameters.AddWithValue("@Email", email);

                        connection.Open();
                        command.ExecuteNonQuery();
                        return true; // Signup successful
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Username or email already exists"))
                {
                    Console.WriteLine("Duplicate entry detected.");
                }
                else
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        // Login method with hashed password validation
        public static User Login(string username, string password)
        {
            try
            {
                string hashedPassword = HashPassword(password); // Hash the input password

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "LOGIN_USER"; // Stored procedure name
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", hashedPassword); // Compare hashed passwords

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    UserID = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    Role = reader.GetString(2),
                                    Email = reader.GetString(3)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        // Hashing function
        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}