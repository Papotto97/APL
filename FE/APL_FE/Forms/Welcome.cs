using APL_FE.Models;
using APL_FE.RestClients;
using System;
using System.Windows.Forms;

namespace APL_FE.Forms
{
    public partial class Welcome : Form
    {
        //private readonly UsersDAO _userDAO;
        private readonly BERestClient _restClientBE;

        public Welcome()
        {
            InitializeComponent();

            //_userDAO = new UsersDAO();
            _restClientBE = new BERestClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            string loginUser = usernameField.Text;
            string passwordUser = passwordField.Text;

            if (string.IsNullOrEmpty(loginUser) || string.IsNullOrEmpty(passwordUser))
                MessageBox.Show("Please check the Username and Password fields");
            else
            {
                //var user = _userDAO.GetUserByUsernameAndPassword(loginUser, passwordUser);
                var user = _restClientBE.GetUserByUsernameAndPassword(loginUser, passwordUser);

                if (user != null)
                {
                    UserInfo.loggedUser = user;

                    Dashboard dashboard = new Dashboard();
                    this.Hide();
                    dashboard.Show();

                    MessageBox.Show(string.Format("Welcome {0}", loginUser));
                }
                else
                    MessageBox.Show("Retry please");
            }
        }

        private void checkLoginShowPassword_CheckedChanged(object sender, EventArgs e)
        {

            if (checkLoginShowPassword.Checked)
            {
                passwordField.UseSystemPasswordChar = false;
            }
            else
            {
                passwordField.UseSystemPasswordChar = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Papotto97");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/lucarest94");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/salvorusso");
        }
    }
}
