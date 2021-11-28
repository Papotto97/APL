using APL_FE.Models;
using APL_FE.Models.Entities;
using APL_FE.RestClients;
using APL_FE.Utils.IMDB.Models;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace APL_FE.Forms.Inner
{
    public partial class SearchFilmsForm : Form
    {
        private readonly IMDBRestClient _restClientIMDB;
        private readonly BERestClient _restClientBE;
        //private readonly SearchesDAO _searchesDAO;
        //private FavouritesDAO _favouritesDAO;

        private readonly Dashboard _parentForm;

        public SearchFilmsForm(Form parent)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;

            _restClientIMDB = new IMDBRestClient();
            _restClientBE = new BERestClient();
            //_searchesDAO = new SearchesDAO();
            //_favouritesDAO = new FavouritesDAO();

            _parentForm = (Dashboard)parent;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var res = _restClientIMDB.SearchMovie(movieName.Text);

            DataGridView dataGridView = PrepareDataGrid(res);

            if (dataGridView.RowCount != 0)
                dataGridView.Rows.Clear();

            if (res.ErrorMessage != null && string.IsNullOrEmpty(res.ErrorMessage))
            {

                foreach (var item in res.Results)
                {
                    //_searchesDAO.InsertNewSearch(new UserSearches
                    //{
                    //    ErrorMessage = res.ErrorMessage,
                    //    MovieId = item.Id,
                    //    MovieTitle = item.Title,
                    //    SearchType = res.SearchType,
                    //    User = UserInfo.loggedUser.Username,
                    //    Expression = movieName.Text
                    //});
                    _restClientBE.InsertNewSearch(new UserSearches
                    {
                        ErrorMessage = res.ErrorMessage,
                        MovieId = item.Id,
                        MovieTitle = item.Title,
                        SearchType = res.SearchType,
                        User = UserInfo.loggedUser,
                        Expression = movieName.Text
                    });

                    //HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(item.Image);
                    //myRequest.Method = "GET";
                    //HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                    //Bitmap bmp = new Bitmap(myResponse.GetResponseStream());
                    //myResponse.Close();

                    dataGridView.Rows.Add(item.Id, item.Title, item.Description, item.Image);
                }

                //dataGridView.Show();
                //panelResults.Show();
                _parentForm.SetResultPanel(dataGridView);

                Console.Out.WriteLine(JsonConvert.SerializeObject(res));
            }
            else
                MessageBox.Show("Please check the fields");
        }

        private DataGridView PrepareDataGrid(SearchData results)
        {
            DataGridView dataGridView1 = new DataGridView();
            DataGridViewTextBoxColumn movieIdColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn titleColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn imageColumn = new DataGridViewTextBoxColumn();
            //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();

            movieIdColumn.HeaderText = "Movie ID";
            movieIdColumn.Name = "movieIdColumn";
            movieIdColumn.ReadOnly = true;
            movieIdColumn.Width = 80;

            titleColumn.HeaderText = "Title";
            titleColumn.Name = "titleColumn";
            titleColumn.ReadOnly = true;
            titleColumn.Width = 55;

            descriptionColumn.HeaderText = "Description";
            descriptionColumn.Name = "descriptionColumn";
            descriptionColumn.ReadOnly = true;
            descriptionColumn.Width = 94;

            imageColumn.HeaderText = "Image";
            imageColumn.Name = "imageColumn";
            imageColumn.ReadOnly = true;
            imageColumn.Width = 67;
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
            titleColumn,
            descriptionColumn,
            imageColumn});
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
            dataGridView1.ReadOnly = true;
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
            dataGridView1.RowHeaderMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.DataGridView1_RowHeaderMouseDoubleClick);
            dataGridView1.Size = new Size(1080, 323);
            dataGridView1.TabIndex = 0;

            return dataGridView1;
        }

        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            StringBuilder messageBoxCS;
            DataGridView datagrid = (DataGridView)sender;
            string movieId = datagrid.Rows[e.RowIndex].Cells[0].Value.ToString();

            //if (_favouritesDAO.GetFavouriteByMovieIdAndUser(movieId, UserInfo.loggedUser) == null)
            if (_restClientBE.GetFavouriteByMovieIdAndUser(movieId, UserInfo.loggedUser) == null)
            {
                if (MessageBox.Show("The selected film is not among your favorites, do you want to add it?", "Add movies to your favorites", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //if (_favouritesDAO.InsertNewFavourite(movieId, UserInfo.loggedUser))
                    if (_restClientBE.InsertFavourite(new Favourites { ImdbId = movieId, User = UserInfo.loggedUser }))
                    {
                        messageBoxCS = new StringBuilder();
                        messageBoxCS.AppendFormat("{0} = {1}", "MovieId", movieId);
                        messageBoxCS.AppendLine();
                        MessageBox.Show(messageBoxCS.ToString(), "Added");
                    }
                }
            }
            else
                MessageBox.Show("Movie already in your favorites", "Add movies to your favorites");
        }
    }
}
