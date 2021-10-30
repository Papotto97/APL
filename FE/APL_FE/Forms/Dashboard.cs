using APL_FE.DAO;
using APL_FE.Forms.Inner;
using APL_FE.Models;
using APL_FE.Utils.IMDB;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace APL_FE.Forms
{
    public partial class Dashboard : Form
    {
        private IMDBRestClient _restClient;
        private SearchesDAO _searchesDAO;

        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        public Dashboard()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;

            _restClient = new IMDBRestClient();
            _searchesDAO = new SearchesDAO();

            panelResults.Hide();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PanelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            loggedUser.Text = UserInfo.loggedUsername;
            loggedUser.Visible = true;

            panelFormCentral.Hide();
            panelResults.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are trying to close the application", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void OpenOnPanelFormCentral(object child)
        {
            if (panelFormCentral.Controls.Count > 0)
            {
                Form control = (Form)panelFormCentral.Controls[0];
                this.panelFormCentral.Controls.Clear();
                control.Close();
            }
            if (child != null)
            {
                Form form = child as Form;
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                panelFormCentral.Controls.Add(form);
                panelFormCentral.Tag = form;
                form.Show();
                panelFormCentral.Show();
            }
        }

        private void searchFilmsButton_Click(object sender, EventArgs e)
        {
            panelResults.Hide();
            if (panelResults.Controls.Count > 0)
                panelResults.Controls.Clear();

            SearchFilmsForm form = new SearchFilmsForm(this);
            OpenOnPanelFormCentral(form);
        }

        public void SetResultPanel(Control control)
        {
            if (panelResults.Controls.Count > 0)
                panelResults.Controls.Clear();

            panelResults.Controls.Add(control);

            panelResults.Show();
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            panelFormCentral.Hide();
            panelResults.Hide();

            if (panelResults.Controls.Count > 0)
                panelResults.Controls.Clear();

            if (panelFormCentral.Controls.Count > 0)
                panelFormCentral.Controls.Clear();
        }

        private void yourFavourites_Click(object sender, EventArgs e)
        {
            panelResults.Hide();
            if (panelResults.Controls.Count > 0)
                panelResults.Controls.Clear();

            YourFavouritesMovies form = new YourFavouritesMovies(this);
            OpenOnPanelFormCentral(form);
        }
    }
}
