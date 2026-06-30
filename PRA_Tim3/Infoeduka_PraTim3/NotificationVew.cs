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
    public partial class NotificationVew : Form
    {
        public NotificationVew()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NotificationsForm form = new NotificationsForm();

            this.Hide();
            form.ShowDialog();
            this.Show();

            LoadNotifications();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CourseRepository repo = new CourseRepository();

            if (dgvNotifications.CurrentRow == null)
            {
                MessageBox.Show("Odaberi obavijest za izmjenu.", "Izmjena obavijesti", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NotificationsForm form = new NotificationsForm(Convert.ToInt32(dgvNotifications.CurrentRow.Cells["Id"].Value), dgvNotifications.CurrentRow.Cells["Title"].Value.ToString(), repo.GetCourseById(Convert.ToInt32(dgvNotifications.CurrentRow.Cells["CourseId"].Value)).Name, dgvNotifications.CurrentRow.Cells["Description"].Value.ToString());

            this.Hide();
            form.ShowDialog();
            this.Show();

            LoadNotifications();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNotifications.CurrentRow == null)
            {
                MessageBox.Show("Odaberi obavijest za brisanje.", "Brisanje obavijesti", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvNotifications.CurrentRow.Cells["Id"].Value);

            NotificationRepository repo = new NotificationRepository();
            repo.DeleteNotification(id);

            MessageBox.Show("Obavijest uspješno obrisana.", "Brisanje obavijesti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadNotifications();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void NotificationVew_Load(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        private void LoadNotifications()
        {
            NotificationRepository repo = new NotificationRepository();

            if (AppSession.CurrentUser.Role == "Administrator")
            {
                dgvNotifications.DataSource = repo.GetAllNotifications();
            }
            else
            {
                dgvNotifications.DataSource = repo.GetAllNotifications().Where(n => n.CreatorId == AppSession.CurrentUser.Id).ToList();
            }
        }

        private void dgvNotifications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
    }
}
