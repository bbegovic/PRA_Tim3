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
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }

        private void LoadUsers()
        {
            UserRepository repo = new UserRepository();

            dgvUsers.DataSource = repo.GetAllUsers();
            if (dgvUsers.Columns["Id"] != null)
                dgvUsers.Columns["Id"].Visible = false;

            if (dgvUsers.Columns["PasswordHash"] != null)
                dgvUsers.Columns["PasswordHash"].Visible = false;
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            RemoveHighlight();
        }

        private void RemoveHighlight()
        {
            dgvUsers.ClearSelection();
            dgvUsers.CurrentCell = null;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text) || string.IsNullOrWhiteSpace(tbLastName.Text) ||
                string.IsNullOrWhiteSpace(tbEmail.Text) || string.IsNullOrWhiteSpace(tbPassword.Text) ||
                !gbRole.Controls.OfType<RadioButton>().Any(r => r.Checked))
            {
                MessageBox.Show("Popuni sva polja.", "Dodavanje korisnika", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String role = gbRole.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked)?.Text;

            UserRepository repo = new UserRepository();

            if (repo.GetAllUsers().Any(u => u.Email == tbEmail.Text))
            {
                MessageBox.Show("Korisnik s istim emailom već postoji.", "Dodavanje korisnika", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = new User
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Email = tbEmail.Text,
                PasswordHash = tbPassword.Text,
                Role = role == "Predavač" ? "Predavac" : role
            };

            repo.AddUser(user);

            MessageBox.Show("Korisnik uspješno dodan.", "Novi korisnik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsers();

            tbFirstName.Clear();
            tbLastName.Clear();
            tbEmail.Clear();
            tbPassword.Clear();
            gbRole.Controls.OfType<RadioButton>().ToList().ForEach(r => r.Checked = false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Odaberi korisnika za izmjenu.", "Izmjena korisnika", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbFirstName.Text) || string.IsNullOrWhiteSpace(tbLastName.Text) ||
                string.IsNullOrWhiteSpace(tbEmail.Text) ||
                !gbRole.Controls.OfType<RadioButton>().Any(r => r.Checked))
            {
                MessageBox.Show("Popuni sva polja.", "Izmjena korisnika", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value);

            User user = new User
            {
                Id = id,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Email = tbEmail.Text,
                PasswordHash = tbPassword.Text,
                Role = gbRole.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked)?.Text
            };

            UserRepository repo = new UserRepository();
            repo.UpdateUser(user);

            MessageBox.Show("Korisnik uspješno izmijenjen.", "Izmjena korisnika", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Odaberi korisnika za brisanje.", "Brisanje korisnika", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value);

            UserRepository repo = new UserRepository();
            repo.DeleteUser(id);

            MessageBox.Show("Korisnik uspješno obrisan.", "Brisanje korisnika", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsers();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                tbFirstName.Text = row.Cells["FirstName"].Value?.ToString();
                tbLastName.Text = row.Cells["LastName"].Value?.ToString();
                tbEmail.Text = row.Cells["Email"].Value?.ToString();
                // tbPassword.Text = row.Cells["PasswordHash"].Value?.ToString();
                tbPassword.Clear();
                bool isActive = Convert.ToBoolean(row.Cells["Role"].Value?.ToString() == "Predavac");

                rbLecturer.Checked = isActive;
                rbAdmin.Checked = !isActive;
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
