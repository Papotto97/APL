using APL_FE.Models;
using APL_FE.Models.Entities;
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

        private void SigninButton_Click(object sender, EventArgs e)
        {
            string loginUser = usernameField.Text;
            string passwordUser = passwordField.Text;

            if (string.IsNullOrEmpty(loginUser) || string.IsNullOrEmpty(passwordUser))
                MessageBox.Show("Please check the Username and Password fields");
            else
            {
                var user = GetUser(loginUser, passwordUser);

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

        private void SignupButton_Click(object sender, EventArgs e)
        {
            string usernameUser = usernameField.Text;
            string passwordUser = passwordField.Text;
            string emailUser = emailField.Text;
            string nameUser = nameField.Text;
            string surnameUser = surnameField.Text;

            if (string.IsNullOrEmpty(usernameUser) || string.IsNullOrEmpty(passwordUser) || string.IsNullOrEmpty(emailUser) || string.IsNullOrEmpty(nameUser) || string.IsNullOrEmpty(surnameUser))
                MessageBox.Show("Please check that all fields are filled on the Sign up form");
            else
            {
                var user = new User { Username = usernameUser, Password = passwordUser, Name = nameUser, Email = emailUser, Surname = surnameUser };
                if (_restClientBE.InsertNewUser(user))
                {
                    UserInfo.loggedUser = user;

                    Dashboard dashboard = new Dashboard();
                    this.Hide();
                    dashboard.Show();

                    MessageBox.Show(string.Format("Welcome {0}", usernameUser));
                }
                else
                    MessageBox.Show("Retry please");
            }
        }

        private void CheckLoginShowPassword_CheckedChanged(object sender, EventArgs e)
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

        private User GetUser(string username, string password)
        {
            //var user = _userDAO.GetUserByUsernameAndPassword(loginUser, passwordUser);
            var user = _restClientBE.GetUserByUsernameAndPassword(username, password);

            return user != null ? user : null;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Papotto97");
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/lucarest94");
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/salvorusso");
        }
    }
}
