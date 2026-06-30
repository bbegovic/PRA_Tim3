using System;
using System.Collections.Generic;
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

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users";

                SqlCommand comm = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PasswordHash = reader["PasswordHash"].ToString(),
                        Role = reader["Role"].ToString()
                    }
                    );
                }

                return users;
            }
        }

        public void AddUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Users
                                (FirstName, LastName, Email, PasswordHash, Role)
                                VALUES
                                (@FirstName, @LastName, @Email, @PasswordHash, @Role)";

                SqlCommand comm = new SqlCommand(query, conn);

                comm.Parameters.AddWithValue("@FirstName", user.FirstName);
                comm.Parameters.AddWithValue("@LastName", user.LastName);
                comm.Parameters.AddWithValue("@Email", user.Email);
                comm.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                comm.Parameters.AddWithValue("@Role", user.Role);

                conn.Open();
                comm.ExecuteNonQuery();
            }
        }


        public void UpdateUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Users
                                SET FirstName = @FirstName,
                                    LastName = @LastName,
                                    Email = @Email,
                                    PasswordHash = @PasswordHash,
                                    Role = @Role
                                WHERE Id = @Id";

                SqlCommand comm = new SqlCommand(query, conn);

                comm.Parameters.AddWithValue("@Id", user.Id);
                comm.Parameters.AddWithValue("@FirstName", user.FirstName);
                comm.Parameters.AddWithValue("@LastName", user.LastName);
                comm.Parameters.AddWithValue("@Email", user.Email);
                comm.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                comm.Parameters.AddWithValue("@Role", user.Role);

                conn.Open();
                comm.ExecuteNonQuery();
            }
        }
        public void UpdateUserWithoutPassword(User user)
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        string query = @"UPDATE Users
                        SET FirstName = @FirstName,
                            LastName = @LastName,
                            Email = @Email,
                            Role = @Role
                        WHERE Id = @Id";

        SqlCommand comm = new SqlCommand(query, conn);

        comm.Parameters.AddWithValue("@Id", user.Id);
        comm.Parameters.AddWithValue("@FirstName", user.FirstName);
        comm.Parameters.AddWithValue("@LastName", user.LastName);
        comm.Parameters.AddWithValue("@Email", user.Email);
        comm.Parameters.AddWithValue("@Role", user.Role);

        conn.Open();
        comm.ExecuteNonQuery();
    }
}

        public void DeleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Users WHERE Id = @Id";

                SqlCommand comm = new SqlCommand(query, conn);

                comm.Parameters.AddWithValue("@Id", id);

                conn.Open();
                comm.ExecuteNonQuery();
            }
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