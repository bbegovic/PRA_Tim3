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
    public partial class LecturerDashboardForm : Form
    {
        private LoginForm1 login;
        public LecturerDashboardForm(LoginForm1 loginForma)
        {
            InitializeComponent();
            login = loginForma;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NotificationVew form = new NotificationVew();

            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void LecturerDashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Jeste li sigurni da se želite odjaviti?", "Potvrda odjave", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                login.Show();
            }

        }
    }
}
