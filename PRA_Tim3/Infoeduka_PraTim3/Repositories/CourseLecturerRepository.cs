using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Infoeduka_PraTim3.Models;

namespace Infoeduka_PraTim3.Repositories
{
    public class CourseLecturerRepository
    {
        private readonly string connectionString;

        public CourseLecturerRepository()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["InfoedukaDb"]
                .ConnectionString;
        }

        public List<CourseLecturer> GetAllCoursesLecturers()
        {
            List<CourseLecturer> coursesLecturers = new List<CourseLecturer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM CourseLecturers";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    coursesLecturers.Add(new CourseLecturer
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CourseId = Convert.ToInt32(reader["CourseId"]),
                        LecturerId = Convert.ToInt32(reader["LecturerId"])

                    });
                }
            }

            return coursesLecturers;
        }

        public void AddCourseLecturer(CourseLecturer courseLecturer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO CourseLecturers (CourseId,LecturerId)
                         VALUES (@CourseId, @LecturerId)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@CourseId", courseLecturer.CourseId);
                command.Parameters.AddWithValue("@LecturerId", courseLecturer.LecturerId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteByCourseId(int courseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM CourseLecturers WHERE CourseId = @CourseId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseId", courseId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<int> GetLecturerIdsForCourse(int courseId)
        {
            List<int> lecturerIds = new List<int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT LecturerId FROM CourseLecturers WHERE CourseId = @CourseId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseId", courseId);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lecturerIds.Add(Convert.ToInt32(reader["LecturerId"]));
                }
            }

            return lecturerIds;
        }


    }
}