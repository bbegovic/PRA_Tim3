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
    public partial class AdminDashboardForm : Form
    {
        private LoginForm1 login;
        public AdminDashboardForm(LoginForm1 formLogin)
        {
            InitializeComponent();
            login = formLogin;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();

            this.Hide();
            usersForm.ShowDialog();
            this.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CoursesForm coursesForm = new CoursesForm();

            this.Hide();           // sakrij Admin Dashboard
            coursesForm.ShowDialog(); // otvori CoursesForm
            this.Show();           // vrati Admin Dashboard kad zatvoriš CoursesForm
        }
        private void btnLecturers_Click(object sender, EventArgs e)
        {
            LecturersForm lecturersForm = new LecturersForm();

            this.Hide();
            lecturersForm.ShowDialog();
            this.Show();
        }
        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("Jeste li sigurni da se želite odjaviti?", "Potvrda odjave", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                login.Show();
            }
            
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            NotificationVew form = new NotificationVew();

            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
