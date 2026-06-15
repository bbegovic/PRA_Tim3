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
    public partial class LoginForm1 : Form
    {
        public LoginForm1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userRepository = new UserRepository();

            var user = userRepository.GetUserByEmailAndPassword(
                txtEmail.Text,
                txtPassword.Text
            );

            if (user == null)
            {
                MessageBox.Show("Neispravna e-mail adresa ili lozinka.");
                return;
            }

            if (user.Role == "Administrator")
            {
                AdminDashboardForm adminForm = new AdminDashboardForm();
                adminForm.Show();
                this.Hide();
            }
            else if (user.Role == "Predavac")
            {
                LecturerDashboardForm lecturerForm = new LecturerDashboardForm();
                lecturerForm.Show();
                this.Hide();
            }
        }
    }
}
