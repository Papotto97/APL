using APL_FE.DAO;
using APL_FE.Models;
using System;
using System.Windows.Forms;

namespace APL_FE.Forms
{
    public partial class Welcome : Form
    {
        private UsersDAO _userDAO;
        public Welcome()
        {
            InitializeComponent();
            _userDAO = new UsersDAO();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void signinButton_Click(object sender, EventArgs e)
        {

            string loginUser = usernameField.Text;
            string passwordUser = passwordField.Text;

            var user =_userDAO.GetUserByUsernameAndPassword(loginUser, passwordUser);

            if (user != null)
            {
                UserInfo.loggedUsername = user.Username;

                Dashboard dashboard = new Dashboard();
                this.Hide();
                dashboard.Show();

                MessageBox.Show(string.Format("Welcome {0}", loginUser));
            }
            else
                MessageBox.Show("Retry please");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UsernameField_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLoginPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void signupButton_Click(object sender, EventArgs e)
        {

        }
    }
}
