using Infoeduka_PraTim3.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Infoeduka_PraTim3.Repositories
{
    public class LecturerRepository
    {
        private readonly string connectionString;

        public LecturerRepository()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["InfoedukaDb"]
                .ConnectionString;
        }

        public List<User> GetAllLecturers()
        {
            List<User> lecturers = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Role = 'Predavac'";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lecturers.Add(new User
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PasswordHash = reader["PasswordHash"].ToString(),
                        Role = reader["Role"].ToString()
                    });
                }
            }

            return lecturers;
        }

        public void AddLecturer(User lecturer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Users
                                (FirstName, LastName, Email, PasswordHash, Role)
                                VALUES
                                (@FirstName, @LastName, @Email, @PasswordHash, 'Predavac')";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@FirstName", lecturer.FirstName);
                command.Parameters.AddWithValue("@LastName", lecturer.LastName);
                command.Parameters.AddWithValue("@Email", lecturer.Email);
                command.Parameters.AddWithValue("@PasswordHash", lecturer.PasswordHash);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateLecturer(User lecturer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Users
                                SET FirstName = @FirstName,
                                    LastName = @LastName,
                                    Email = @Email,
                                    PasswordHash = @PasswordHash
                                WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", lecturer.Id);
                command.Parameters.AddWithValue("@FirstName", lecturer.FirstName);
                command.Parameters.AddWithValue("@LastName", lecturer.LastName);
                command.Parameters.AddWithValue("@Email", lecturer.Email);
                command.Parameters.AddWithValue("@PasswordHash", lecturer.PasswordHash);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteLecturer(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Users WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}