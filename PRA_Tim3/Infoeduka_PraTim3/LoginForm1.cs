using Infoeduka_PraTim3.Helpers;
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
        private string initEmail;
        private string initePassword;
        
        public LoginForm1()
        {
            InitializeComponent();
            initEmail = txtEmail.Text;
            initePassword = txtPassword.Text;





        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userRepository = new UserRepository();

            var user = userRepository.GetUserByEmailAndPassword(
                txtEmail.Text,
                txtPassword.Text
            );

            AppSession.CurrentUser = user;

            if (user == null)
            {
                MessageBox.Show("Neispravna e-mail adresa ili lozinka.");
                return;
            }

            if (user.Role == "Administrator")
            {
                AdminDashboardForm adminForm = new AdminDashboardForm(this);
                adminForm.Show();
                this.Hide();
            }
            else if (user.Role == "Predavac")
            {
                LecturerDashboardForm lecturerForm = new LecturerDashboardForm(this);
                lecturerForm.Show();
                this.Hide();
              
            }
            TextBoxReset();
        }

        private void TextBoxReset()
        {
            txtEmail.Text = null;
            txtPassword.Text = null;
            txtEmail.PlaceholdeText = initEmail;
            txtPassword.PlaceholdeText = initePassword;
        }

        private void LoginForm1_Load(object sender, EventArgs e)
        {
            txtEmail.Text = "admin@infoeduka.hr";
            txtPassword.Text = "admin123";
            btnLogin.PerformClick();
            
        }

        private void LoginForm1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
