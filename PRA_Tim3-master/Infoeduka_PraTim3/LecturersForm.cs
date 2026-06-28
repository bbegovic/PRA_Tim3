using System;
using System.Windows.Forms;
using Infoeduka_PraTim3.Models;
using Infoeduka_PraTim3.Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Infoeduka_PraTim3
{
    public partial class LecturersForm : Form
    {
        public LecturersForm()
        {
            InitializeComponent();
        }

        private void LoadLecturers()
        {
            LecturerRepository repository = new LecturerRepository();
            dgvLecturers.DataSource = repository.GetAllLecturers();
            if (dgvLecturers.Columns["Id"] != null)
                dgvLecturers.Columns["Id"].Visible = false;

            if (dgvLecturers.Columns["PasswordHash"] != null)
                dgvLecturers.Columns["PasswordHash"].Visible = false;

            if (dgvLecturers.Columns["Role"] != null)
                dgvLecturers.Columns["Role"].Visible = false;
        }

        private void LecturersForm_Load(object sender, EventArgs e)
        {
            LoadLecturers();
            RemoveHighliht();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User lecturer = new User
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                PasswordHash = txtPassword.Text,
                Role = "Predavac"
            };

            LecturerRepository repository = new LecturerRepository();
            repository.AddLecturer(lecturer);

            MessageBox.Show("Predavač je dodan.");
            LoadLecturers();

            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
        }

        private void dgvLecturers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvLecturers.CurrentRow == null)
            {
                MessageBox.Show("Odaberi predavača za uređivanje.");
                return;
            }

            int id = Convert.ToInt32(dgvLecturers.CurrentRow.Cells["Id"].Value);

            User lecturer = new User
            {
                Id = id,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                PasswordHash = txtPassword.Text,
                Role = "Predavac"
            };

            LecturerRepository repository = new LecturerRepository();
            repository.UpdateLecturer(lecturer);

            MessageBox.Show("Predavač je uređen.");
            LoadLecturers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLecturers.CurrentRow == null)
            {
                MessageBox.Show("Odaberi predavača za brisanje.");
                return;
            }

            int id = Convert.ToInt32(dgvLecturers.CurrentRow.Cells["Id"].Value);

            LecturerRepository repository = new LecturerRepository();
            repository.DeleteLecturer(id);

            MessageBox.Show("Predavač je obrisan.");
            LoadLecturers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //private void dgvLecturers_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        txtFirstName.Text = dgvLecturers.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
        //        txtLastName.Text = dgvLecturers.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
        //        txtEmail.Text = dgvLecturers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
        //        txtPassword.Text = dgvLecturers.Rows[e.RowIndex].Cells["PasswordHash"].Value.ToString();
        //    }
        //}

    

        private void LecturersForm_Click(object sender, EventArgs e)
        {
            RemoveHighliht();
        }

        private void RemoveHighliht()
        {
            dgvLecturers.ClearSelection();
            dgvLecturers.CurrentCell = null;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            
        }

        private void dgvLecturers_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow red = dgvLecturers.Rows[e.RowIndex];

                txtFirstName.Text = red.Cells["FirstName"].Value?.ToString();
                txtLastName.Text = red.Cells["LastName"].Value?.ToString();
                txtEmail.Text = red.Cells["Email"].Value?.ToString();
                txtPassword.Text = red.Cells["PasswordHash"].Value?.ToString();

            }


        }
    }
}