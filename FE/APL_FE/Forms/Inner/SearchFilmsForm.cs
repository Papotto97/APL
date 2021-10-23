using APL_FE.DAO;
using APL_FE.Models;
using APL_FE.Models.Entities;
using APL_FE.Utils.IMDB;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace APL_FE.Forms.Inner
{
    public partial class SearchFilmsForm : Form
    {
        private IMDBRestClient _restClient;
        private SearchesDAO _searchesDAO;

        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        public SearchFilmsForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;

            _restClient = new IMDBRestClient();
            _searchesDAO = new SearchesDAO();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
        }

        private void movieName_TextChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void movieNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
