
using APL_FE.Models;

namespace APL_FE.Forms.Inner
{
    partial class SearchFilmsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchFilmsForm));
            this.movieName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.movieNameLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // movieName
            // 
            this.movieName.Location = new System.Drawing.Point(177, 147);
            this.movieName.Name = "movieName";
            this.movieName.Size = new System.Drawing.Size(225, 20);
            this.movieName.TabIndex = 45;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::APL_FE.Properties.Resources.film_icon_60206e1eee5c6;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(532, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 219);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // movieNameLabel
            // 
            this.movieNameLabel.AutoSize = true;
            this.movieNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieNameLabel.Location = new System.Drawing.Point(44, 143);
            this.movieNameLabel.Name = "movieNameLabel";
            this.movieNameLabel.Size = new System.Drawing.Size(127, 24);
            this.movieNameLabel.TabIndex = 46;
            this.movieNameLabel.Text = "Movie Name";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(177, 176);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(225, 23);
            this.searchButton.TabIndex = 47;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 31);
            this.label1.TabIndex = 48;
            this.label1.Text = "Search your favourite film";
            // 
            // SearchFilmsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(877, 265);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.movieName);
            this.Controls.Add(this.movieNameLabel);
            this.Controls.Add(this.searchButton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchFilmsForm";
            this.Opacity = 0.95D;
            this.Text = "SearchFilmsForm";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox movieName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label movieNameLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label1;
    }
}

