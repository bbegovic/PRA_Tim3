using System;
using System.Configuration;
using System.Data.SqlClient;
using Infoeduka_PraTim3.Models;

namespace Infoeduka_PraTim3.Repositories
{
    public class UserRepository
    {
        private readonly string connectionString;

        public UserRepository()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["InfoedukaDb"]
                .ConnectionString;
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT Id, FirstName, LastName, Email, PasswordHash, Role
                                 FROM Users
                                 WHERE Email = @Email AND PasswordHash = @Password";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PasswordHash = reader["PasswordHash"].ToString(),
                        Role = reader["Role"].ToString()
                    };
                }

                return null;
            }
        }
    }
}