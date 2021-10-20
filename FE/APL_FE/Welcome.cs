using APL_FE.DAO;
using APL_FE.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APL_FE
{
    public partial class Welcome : Form
    {
        private UserDAO _userDAO;
        public Welcome()
        {
            InitializeComponent();
            _userDAO = new UserDAO();
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

                Dashboard loginForm = new Dashboard();
                this.Hide();
                loginForm.Show();
                MessageBox.Show(String.Format("Welcome {0}", loginUser));
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
