
using APL_FE.Models;

namespace APL_FE.Forms.Inner
{
    partial class DashboardPlotForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardPlotForm));
            this.refreshDashButton = new System.Windows.Forms.Button();
            this.pictureBoxPlot1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxPlot2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot2)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshDashButton
            // 
            this.refreshDashButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.refreshDashButton.FlatAppearance.BorderSize = 0;
            this.refreshDashButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.refreshDashButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.refreshDashButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshDashButton.ForeColor = System.Drawing.Color.Black;
            this.refreshDashButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refreshDashButton.Location = new System.Drawing.Point(20, 24);
            this.refreshDashButton.Name = "refreshDashButton";
            this.refreshDashButton.Size = new System.Drawing.Size(151, 25);
            this.refreshDashButton.TabIndex = 49;
            this.refreshDashButton.Text = "Refresh Dashboard";
            this.refreshDashButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.refreshDashButton.UseVisualStyleBackColor = true;
            this.refreshDashButton.Click += new System.EventHandler(this.refreshDashButton_Click);
            // 
            // pictureBoxPlot1
            // 
            this.pictureBoxPlot1.Location = new System.Drawing.Point(189, 12);
            this.pictureBoxPlot1.Name = "pictureBoxPlot1";
            this.pictureBoxPlot1.Size = new System.Drawing.Size(342, 240);
            this.pictureBoxPlot1.TabIndex = 50;
            this.pictureBoxPlot1.TabStop = false;
            // 
            // pictureBoxPlot2
            // 
            this.pictureBoxPlot2.Location = new System.Drawing.Point(562, 12);
            this.pictureBoxPlot2.Name = "pictureBoxPlot2";
            this.pictureBoxPlot2.Size = new System.Drawing.Size(342, 240);
            this.pictureBoxPlot2.TabIndex = 51;
            this.pictureBoxPlot2.TabStop = false;
            // 
            // DashboardPlotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tomato;
            this.ClientSize = new System.Drawing.Size(916, 265);
            this.Controls.Add(this.pictureBoxPlot2);
            this.Controls.Add(this.pictureBoxPlot1);
            this.Controls.Add(this.refreshDashButton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DashboardPlotForm";
            this.Opacity = 0.95D;
            this.Text = "SearchFilmsForm";
            this.Load += new System.EventHandler(this.DashboardPlotForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button refreshDashButton;
        private System.Windows.Forms.PictureBox pictureBoxPlot1;
        private System.Windows.Forms.PictureBox pictureBoxPlot2;
    }
}

