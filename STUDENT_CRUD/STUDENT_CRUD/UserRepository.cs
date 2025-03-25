using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace STUDENT_CRUD
{
    public class UserRepository
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

        public static bool Signup(string username, string pwd, string role, string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT_USER";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", pwd); // In a real app, hash the password
                        command.Parameters.AddWithValue("@role", role);
                        command.Parameters.AddWithValue("@email", email);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                      
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
               
                Console.WriteLine("SQL Error: " + ex.Message);

                
                return false;
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error: " + ex.Message);

                
                return false;
            }
        }
        public static User Login(string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                  
                    string query = "LOGIN_USER";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                       
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password); 

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
            catch (SqlException ex)
            {
               
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error: " + ex.Message);
            }

         
            return null;
        }
    }

    
}