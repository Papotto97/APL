using APL_FE.DAO;
using APL_FE.Models;
using APL_FE.Models.Entities;
using APL_FE.Utils;
using APL_FE.Utils.IMDB;
using APL_FE.Utils.IMDB.Models;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace APL_FE.Forms.Inner
{
    public partial class DashboardPlotForm : Form
    {
        private RModuleRestClient _RrestClient;

        private readonly Dashboard _parentForm;

        public DashboardPlotForm(Form parent)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;

            _RrestClient = new RModuleRestClient();

            _parentForm = (Dashboard)parent;
        }

        private void DashboardPlotForm_Load(object sender, EventArgs e)
        {
            Bitmap plot1 = LoadPlot(_RrestClient.PLOT1);
            Bitmap plot2 = LoadPlot(_RrestClient.PLOT2);

            pictureBoxPlot1.Image = plot1;
            pictureBoxPlot1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxPlot1.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBoxPlot2.Image = plot2;
            pictureBoxPlot2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxPlot2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private Bitmap LoadPlot(string plot)
        {
            return _RrestClient.SearchPlot(plot);
        }

        private void refreshDashButton_Click(object sender, EventArgs e)
        {
            DashboardPlotForm_Load(sender, e);
        }
    }
}
