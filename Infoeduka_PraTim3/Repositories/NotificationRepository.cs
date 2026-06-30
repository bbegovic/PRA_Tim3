using Infoeduka_PraTim3.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoeduka_PraTim3.Repositories
{
    public class NotificationRepository
    {
        private readonly string connectionString;

        public NotificationRepository()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["InfoedukaDb"]
                .ConnectionString;
        }

        public List<Notification> GetAllNotifications()
        {
            List<Notification> notifications = new List<Notification>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Notifications";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    notifications.Add(new Notification
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CourseId = Convert.ToInt32(reader["CourseId"]),
                        CreatorId = Convert.ToInt32(reader["CreatorId"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        PublishDate = Convert.ToDateTime((reader["PublishDate"])),
                        ExpiryDate = Convert.ToDateTime((reader["ExpiryDate"]))
                    });
                }
            }
            return notifications;
        }

        public void AddNotification(Notification notification)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Notifications
                                (CourseID, CreatorId, Title, Description, PublishDate, ExpiryDate)
                                VALUES
                                (@CourseID, @CreatorId, @Title, @Description, @PublishDate, @ExpiryDate)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@CourseID", notification.CourseId);
                command.Parameters.AddWithValue("@CreatorId", notification.CreatorId);
                command.Parameters.AddWithValue("@Title", notification.Title);
                command.Parameters.AddWithValue("@Description", notification.Description);
                command.Parameters.AddWithValue("@PublishDate", notification.PublishDate);
                command.Parameters.AddWithValue("@ExpiryDate", notification.ExpiryDate);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateNotification(Notification notification)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Notifications
                                SET CourseID = @CourseID,
                                    Title = @Title,
                                    Description = @Description,
                                    PublishDate = @PublishDate,
                                    ExpiryDate =  @ExpiryDate
                                WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", notification.Id);
                command.Parameters.AddWithValue("@CourseId", notification.CourseId);
                command.Parameters.AddWithValue("@Title", notification.Title);
                command.Parameters.AddWithValue("@Description", notification.Description);
                command.Parameters.AddWithValue("@PublishDate", notification.PublishDate);
                command.Parameters.AddWithValue("@ExpiryDate", notification.ExpiryDate);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void DeleteNotification(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Notifications WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
