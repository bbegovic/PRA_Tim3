using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Infoeduka_PraTim3.Models;

namespace Infoeduka_PraTim3.Repositories
{
    public class CourseRepository
    {
        private readonly string connectionString;

        public CourseRepository()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["InfoedukaDb"]
                .ConnectionString;
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Courses";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    courses.Add(new Course
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    });
                }
            }

            return courses;
        }

        public void AddCourse(Course course)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Courses (Name, Description)
                         VALUES (@Name, @Description)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", course.Name);
                command.Parameters.AddWithValue("@Description", course.Description);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void UpdateCourse(Course course)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Courses
                         SET Name = @Name,
                             Description = @Description
                         WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", course.Id);
                command.Parameters.AddWithValue("@Name", course.Name);
                command.Parameters.AddWithValue("@Description", course.Description);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCourse(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Courses WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}