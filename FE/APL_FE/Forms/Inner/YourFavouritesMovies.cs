using APL_FE.DAO;
using APL_FE.Models;
using APL_FE.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace APL_FE.Forms.Inner
{
    public partial class YourFavouritesMovies : Form
    {
        private readonly SearchesDAO _searchesDAO;
        private readonly FavouritesDAO _favouritesDAO;

        private readonly Dashboard _parentForm;

        public YourFavouritesMovies(Form parent)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;

            _searchesDAO = new SearchesDAO();
            _favouritesDAO = new FavouritesDAO();

            _parentForm = (Dashboard)parent;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
        }

        private void showFavourites_Click(object sender, EventArgs e)
        {
            var res = _favouritesDAO.GetFavourites(UserInfo.loggedUsername);

            DataGridView dataGridView = PrepareDataGrid(res);

            if (dataGridView.RowCount != 0)
                dataGridView.Rows.Clear();

            if (res != null)
            {

                foreach (var item in res)
                {

                    //HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(item.Image);
                    //myRequest.Method = "GET";
                    //HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                    //Bitmap bmp = new Bitmap(myResponse.GetResponseStream());
                    //myResponse.Close();

                    var title = _searchesDAO.GetSearchByMovieId(item.MovieId);

                    dataGridView.Rows.Add(item.MovieId, title?.MovieTitle, item.PersonalVote);
                }

                //dataGridView.Show();
                //panelResults.Show();
                _parentForm.SetResultPanel(dataGridView);

                Console.Out.WriteLine(JsonConvert.SerializeObject(res));
            }
        }

        private DataGridView PrepareDataGrid(List<Favourites> results)
        {
            DataGridView dataGridView1 = new DataGridView();
            DataGridViewTextBoxColumn movieIdColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn movieTitleColumn = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn voteColumn = new DataGridViewComboBoxColumn();
            //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();

            movieIdColumn.HeaderText = "Movie ID";
            movieIdColumn.Name = "movieIdColumn";
            movieIdColumn.ReadOnly = true;
            movieIdColumn.Width = 80;
            movieIdColumn.ValueType = typeof(string);

            movieTitleColumn.HeaderText = "Movie Title";
            movieTitleColumn.Name = "movieTitleColumn";
            movieTitleColumn.ReadOnly = true;
            movieTitleColumn.Width = 80;
            movieTitleColumn.ValueType = typeof(string);

            var voteList = new List<string>() { "0", "1", "2", "3", "4", "5" };
            voteColumn.DataSource = voteList;
            voteColumn.HeaderText = "Personal vote";
            voteColumn.Name = "voteColumn";
            voteColumn.ReadOnly = false;
            voteColumn.Width = 80;
            voteColumn.ValueType = typeof(string);

            //imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(60)))), ((int)(((byte)(15)))));
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
            movieIdColumn,
            movieTitleColumn,
            voteColumn});
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = Color.Gainsboro;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            dataGridView1.Location = new Point(10, 10);
            dataGridView1.Margin = new Padding(10);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = Color.IndianRed;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(this.DataGridView1_CellEndEdit);
            dataGridView1.Size = new Size(1080, 323);
            dataGridView1.TabIndex = 0;

            return dataGridView1;
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            StringBuilder messageBoxCS;
            DataGridView datagrid = (DataGridView)sender;
            string movieId = datagrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            string title = datagrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            string vote = datagrid.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (MessageBox.Show("Do you want to update your personal rating for the selected film?", "Update personal rating", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_favouritesDAO.UpdateFavourite(movieId, UserInfo.loggedUsername, vote))
                {
                    messageBoxCS = new StringBuilder();
                    messageBoxCS.AppendFormat("{0} = {1}", "MovieId", movieId);
                    messageBoxCS.AppendLine();
                    messageBoxCS.AppendFormat("{0} = {1}", "Title", title);
                    messageBoxCS.AppendLine();
                    messageBoxCS.AppendFormat("{0} = {1}", "Vote", vote);
                    messageBoxCS.AppendLine();
                    MessageBox.Show(messageBoxCS.ToString(), "Added");
                }
            }
        }
    }
}
