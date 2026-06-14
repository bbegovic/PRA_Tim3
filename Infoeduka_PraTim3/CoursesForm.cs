using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infoeduka_PraTim3.Repositories;

namespace Infoeduka_PraTim3
{
    public partial class CoursesForm : Form
    {
        public CoursesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
        private void dgvCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
