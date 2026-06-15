using System;
using System.Windows.Forms;
using Infoeduka_PraTim3.Models;
using Infoeduka_PraTim3.Repositories;

namespace Infoeduka_PraTim3
{
    public partial class CoursesForm : Form
    {
        public CoursesForm()
        {
            InitializeComponent();
        }

        private void LoadCourses()
        {
            CourseRepository repository = new CourseRepository();
            dgvCourses.DataSource = repository.GetAllCourses();
        }

        private void CoursesForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Course course = new Course
            {
                Name = txtCourseNam.Text,
                Description = txtCourseDescription.Text
            };

            CourseRepository repository = new CourseRepository();
            repository.AddCourse(course);

            MessageBox.Show("Kolegij je dodan.");

            LoadCourses();

            txtCourseNam.Clear();
            txtCourseDescription.Clear();
        }
        private void dgvCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Course course = new Course
            {
                Name = txtCourseNam.Text,
                Description = txtCourseDescription.Text
            };

            CourseRepository repository = new CourseRepository();
            repository.AddCourse(course);

            MessageBox.Show("Kolegij je dodan.");
            LoadCourses();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCourses.CurrentRow == null)
            {
                MessageBox.Show("Odaberi kolegij za uređivanje.");
                return;
            }

            int id = Convert.ToInt32(dgvCourses.CurrentRow.Cells["Id"].Value);

            Course course = new Course
            {
                Id = id,
                Name = txtCourseNam.Text,
                Description = txtCourseDescription.Text
            };

            CourseRepository repository = new CourseRepository();
            repository.UpdateCourse(course);

            MessageBox.Show("Kolegij je uređen.");
            LoadCourses();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCourses.CurrentRow == null)
            {
                MessageBox.Show("Odaberi kolegij za brisanje.");
                return;
            }

            int id = Convert.ToInt32(dgvCourses.CurrentRow.Cells["Id"].Value);

            CourseRepository repository = new CourseRepository();
            repository.DeleteCourse(id);

            MessageBox.Show("Kolegij je obrisan.");
            LoadCourses();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCourseNam.Text = dgvCourses.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtCourseDescription.Text = dgvCourses.Rows[e.RowIndex].Cells["Description"].Value.ToString();
            }
        }
    }
}