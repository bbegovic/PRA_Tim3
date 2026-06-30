using Infoeduka_PraTim3.Helpers;
using Infoeduka_PraTim3.Models;
using Infoeduka_PraTim3.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infoeduka_PraTim3
{
    public partial class NotificationsForm : Form
    {
        private readonly int _editId = -1;
        private readonly string _title;
        private readonly string _course;
        private readonly string _description;

        public NotificationsForm()
        {
            InitializeComponent();
        }

        public NotificationsForm(int id, string title, string course, string description)
        {
            InitializeComponent();

            _editId = id;
            _title = title;
            _course = course;
            _description = description;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CourseRepository courseRepo = new CourseRepository();
            NotificationRepository repo = new NotificationRepository();

            if (_editId < 0)
            {
                Notification notification = new Notification
                {
                    CreatorId = AppSession.CurrentUser.Id,
                    Title = txtTitle.Text,
                    CourseId = courseRepo.GetCourseByName(cbCourse.GetItemText(cbCourse.SelectedItem)).Id,
                    Description = txtDecription.Text,
                    PublishDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddDays(7)
                };

                repo.AddNotification(notification);

                MessageBox.Show("Obavijest uspješno dodana.", "Nova obavijest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Notification notification = new Notification
                {
                    Id = _editId,
                    CreatorId = AppSession.CurrentUser.Id,
                    Title = txtTitle.Text,
                    CourseId = courseRepo.GetCourseByName(cbCourse.GetItemText(cbCourse.SelectedItem)).Id,
                    Description = txtDecription.Text,
                    PublishDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddDays(7)
                };

                repo.UpdateNotification(notification);

                MessageBox.Show("Obavijest uspješno ažurirana.", "Ažuriranje obavijesti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void NotificationsForm_Load(object sender, EventArgs e)
        {
            CourseRepository courseRepo = new CourseRepository();

            foreach (var course in courseRepo.GetAllCourses())
            {
                cbCourse.Items.Add(course.Name);
            }

            if (_editId < 0)
            {
                cbCourse.SelectedIndex = 0;
            } else
            {
                txtTitle.Text = _title;
                cbCourse.SelectedIndex = cbCourse.Items.IndexOf(_course);
                txtDecription.Text = _description;
            }
        }
    }
}
