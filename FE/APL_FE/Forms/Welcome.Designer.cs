
namespace APL_FE.Forms
{
    partial class Welcome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.signin = new System.Windows.Forms.Button();
            this.signup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.usernameField = new System.Windows.Forms.TextBox();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkLoginShowPassword = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // signin
            // 
            this.signin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signin.Location = new System.Drawing.Point(15, 234);
            this.signin.Name = "signin";
            this.signin.Size = new System.Drawing.Size(134, 38);
            this.signin.TabIndex = 0;
            this.signin.Text = "Sign in";
            this.signin.UseVisualStyleBackColor = true;
            this.signin.Click += new System.EventHandler(this.signinButton_Click);
            // 
            // signup
            // 
            this.signup.Cursor = System.Windows.Forms.Cursors.Default;
            this.signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup.Location = new System.Drawing.Point(155, 234);
            this.signup.Name = "signup";
            this.signup.Size = new System.Drawing.Size(134, 38);
            this.signup.TabIndex = 1;
            this.signup.Text = "Sign up";
            this.signup.UseVisualStyleBackColor = true;
            this.signup.Click += new System.EventHandler(this.signupButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Papotto Placido";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(137, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Restivo Luca";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(241, 425);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Russo Salvatore";
            // 
            // usernameField
            // 
            this.usernameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usernameField.Location = new System.Drawing.Point(100, 153);
            this.usernameField.Name = "usernameField";
            this.usernameField.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.usernameField.Size = new System.Drawing.Size(189, 22);
            this.usernameField.TabIndex = 17;
            this.usernameField.TextChanged += new System.EventHandler(this.UsernameField_TextChanged);
            // 
            // passwordField
            // 
            this.passwordField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordField.Location = new System.Drawing.Point(100, 186);
            this.passwordField.Name = "passwordField";
            this.passwordField.Size = new System.Drawing.Size(189, 22);
            this.passwordField.TabIndex = 17;
            this.passwordField.UseSystemPasswordChar = true;
            this.passwordField.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.usernameLabel.Location = new System.Drawing.Point(12, 159);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(83, 16);
            this.usernameLabel.TabIndex = 7;
            this.usernameLabel.Text = "Username:";
            this.usernameLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.passwordLabel.Location = new System.Drawing.Point(12, 192);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(80, 16);
            this.passwordLabel.TabIndex = 8;
            this.passwordLabel.Text = "Password:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::APL_FE.Properties.Resources.film_icon_60206e1eee5c6;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(366, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(422, 351);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // checkLoginShowPassword
            // 
            this.checkLoginShowPassword.AutoSize = true;
            this.checkLoginShowPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.checkLoginShowPassword.ForeColor = System.Drawing.Color.Black;
            this.checkLoginShowPassword.Location = new System.Drawing.Point(294, 188);
            this.checkLoginShowPassword.Name = "checkLoginShowPassword";
            this.checkLoginShowPassword.Size = new System.Drawing.Size(64, 20);
            this.checkLoginShowPassword.TabIndex = 16;
            this.checkLoginShowPassword.Text = "Show";
            this.checkLoginShowPassword.UseVisualStyleBackColor = true;
            this.checkLoginShowPassword.CheckedChanged += new System.EventHandler(this.checkLoginShowPassword_CheckedChanged);
            // 
            // Welcome
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkLoginShowPassword);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.passwordField);
            this.Controls.Add(this.usernameField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.signup);
            this.Controls.Add(this.signin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Programming Languages";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button signin;
        private System.Windows.Forms.Button signup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usernameField;
        private System.Windows.Forms.TextBox passwordField;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.CheckBox checkLoginShowPassword;
    }
}

