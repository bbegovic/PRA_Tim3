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
            String role = gbRole.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked)?.Text;

            User user = new User
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Email = tbEmail.Text,
                PasswordHash = tbPassword.Text,
                Role = role == "Predavač" ? "Predavac" : role
            };

            UserRepository repo = new UserRepository();
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
        }
    }
}
