
using APL_FE.Models;

namespace APL_FE.Forms
{
    partial class Dashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.exitButton = new System.Windows.Forms.Button();
            this.loggedUser = new System.Windows.Forms.Label();
            this.panelResults = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.movieIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchFilmsButton = new System.Windows.Forms.Button();
            this.dashboardButton = new System.Windows.Forms.Button();
            this.panelFormCentral = new System.Windows.Forms.Panel();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.exitButton.Location = new System.Drawing.Point(1045, 12);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(43, 25);
            this.exitButton.TabIndex = 20;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // loggedUser
            // 
            this.loggedUser.AutoSize = true;
            this.loggedUser.BackColor = System.Drawing.Color.Transparent;
            this.loggedUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loggedUser.ForeColor = System.Drawing.Color.Gray;
            this.loggedUser.Location = new System.Drawing.Point(66, 16);
            this.loggedUser.Name = "loggedUser";
            this.loggedUser.Size = new System.Drawing.Size(0, 16);
            this.loggedUser.TabIndex = 21;
            // 
            // panelResults
            // 
            this.panelResults.AutoSize = true;
            this.panelResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.panelResults.Controls.Add(this.dataGridView1);
            this.panelResults.Location = new System.Drawing.Point(0, 357);
            this.panelResults.Margin = new System.Windows.Forms.Padding(0);
            this.panelResults.Name = "panelResults";
            this.panelResults.Padding = new System.Windows.Forms.Padding(10);
            this.panelResults.Size = new System.Drawing.Size(1100, 343);
            this.panelResults.TabIndex = 40;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.movieIdColumn,
            this.titleColumn,
            this.descriptionColumn,
            this.imageColumn});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.dataGridView1.Location = new System.Drawing.Point(10, 10);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1080, 323);
            this.dataGridView1.TabIndex = 0;
            // 
            // movieIdColumn
            // 
            this.movieIdColumn.HeaderText = "Movie ID";
            this.movieIdColumn.Name = "movieIdColumn";
            this.movieIdColumn.ReadOnly = true;
            this.movieIdColumn.Width = 80;
            // 
            // titleColumn
            // 
            this.titleColumn.HeaderText = "Title";
            this.titleColumn.Name = "titleColumn";
            this.titleColumn.ReadOnly = true;
            this.titleColumn.Width = 55;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.HeaderText = "Description";
            this.descriptionColumn.Name = "descriptionColumn";
            this.descriptionColumn.ReadOnly = true;
            this.descriptionColumn.Width = 94;
            // 
            // imageColumn
            // 
            this.imageColumn.HeaderText = "Image";
            this.imageColumn.Name = "imageColumn";
            this.imageColumn.ReadOnly = true;
            this.imageColumn.Width = 67;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.panelTitle.Controls.Add(this.loggedUser);
            this.panelTitle.Controls.Add(this.pictureBox2);
            this.panelTitle.Controls.Add(this.exitButton);
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1100, 50);
            this.panelTitle.TabIndex = 1;
            this.panelTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitle_Paint);
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = global::APL_FE.Properties.Resources.film_icon_60206e1eee5c61;
            this.pictureBox2.Location = new System.Drawing.Point(6, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(54, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(34)))), ((int)(((byte)(39)))));
            this.panel3.Controls.Add(this.searchFilmsButton);
            this.panel3.Controls.Add(this.dashboardButton);
            this.panel3.Location = new System.Drawing.Point(0, 53);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(207, 647);
            this.panel3.TabIndex = 42;
            // 
            // searchFilmsButton
            // 
            this.searchFilmsButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.searchFilmsButton.FlatAppearance.BorderSize = 0;
            this.searchFilmsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.searchFilmsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.searchFilmsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchFilmsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchFilmsButton.ForeColor = System.Drawing.Color.Silver;
            this.searchFilmsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchFilmsButton.Location = new System.Drawing.Point(0, 58);
            this.searchFilmsButton.Margin = new System.Windows.Forms.Padding(0);
            this.searchFilmsButton.Name = "searchFilmsButton";
            this.searchFilmsButton.Size = new System.Drawing.Size(207, 40);
            this.searchFilmsButton.TabIndex = 26;
            this.searchFilmsButton.Text = "Search movies";
            this.searchFilmsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchFilmsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.searchFilmsButton.UseVisualStyleBackColor = true;
            this.searchFilmsButton.Click += new System.EventHandler(this.searchFilmsButton_Click);
            // 
            // dashboardButton
            // 
            this.dashboardButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.dashboardButton.FlatAppearance.BorderSize = 0;
            this.dashboardButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.dashboardButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.dashboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardButton.ForeColor = System.Drawing.Color.Silver;
            this.dashboardButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardButton.Location = new System.Drawing.Point(0, 18);
            this.dashboardButton.Margin = new System.Windows.Forms.Padding(0);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.Size = new System.Drawing.Size(207, 40);
            this.dashboardButton.TabIndex = 25;
            this.dashboardButton.Text = "Dashboard";
            this.dashboardButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.dashboardButton.UseVisualStyleBackColor = true;
            this.dashboardButton.Click += new System.EventHandler(this.dashboardButton_Click);
            // 
            // panelFormCentral
            // 
            this.panelFormCentral.BackColor = System.Drawing.Color.Tomato;
            this.panelFormCentral.Location = new System.Drawing.Point(207, 53);
            this.panelFormCentral.Margin = new System.Windows.Forms.Padding(0);
            this.panelFormCentral.Name = "panelFormCentral";
            this.panelFormCentral.Size = new System.Drawing.Size(893, 304);
            this.panelFormCentral.TabIndex = 43;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.panelPrincipal.Controls.Add(this.panelTitle);
            this.panelPrincipal.Controls.Add(this.panelResults);
            this.panelPrincipal.Controls.Add(this.panelFormCentral);
            this.panelPrincipal.Controls.Add(this.panel3);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1100, 700);
            this.panelPrincipal.TabIndex = 44;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.panelPrincipal);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(680, 500);
            this.Name = "Dashboard";
            this.Opacity = 0.95D;
            this.Text = "Advanced Programming Languages";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panelResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label loggedUser;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelResults;
        private System.Windows.Forms.Panel panelFormCentral;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn movieIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageColumn;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button dashboardButton;
        private System.Windows.Forms.Button searchFilmsButton;
    }
}

