using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MovieCatalog.Models;
using MovieCatalog.Services;

namespace MovieCatalog.Forms
{
    public partial class MainForm : Form
    {
        private MovieRepository movieRepository;

        public MainForm()
        {
            InitializeComponent();
            movieRepository = new MovieRepository("data/movies.json");

            LoadMovies();

            cmbFilterGenre.SelectedIndexChanged += FilterChanged;
            cmbFilterStatus.SelectedIndexChanged += FilterChanged;
            txtSearch.TextChanged += FilterChanged;
        }

        private void LoadMovies()
        {
            flowMovies.Controls.Clear();

            var movies = movieRepository.GetAll();
            string search = txtSearch.Text.ToLower();
            string genreFilter = cmbFilterGenre.SelectedItem?.ToString() ?? "Все";
            string statusFilter = cmbFilterStatus.SelectedItem?.ToString() ?? "Все";

            var filteredMovies = movies.Where(m =>
                (m.Title.ToLower().Contains(search) || m.Description.ToLower().Contains(search)) &&
                (genreFilter == "Все" || m.Genre == genreFilter) &&
                (statusFilter == "Все" || m.Status == statusFilter)
            ).ToList();

            foreach (var movie in filteredMovies)
            {
                var card = CreateMovieCard(movie);
                flowMovies.Controls.Add(card);
            }
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            LoadMovies();
        }

        private Panel CreateMovieCard(Movie movie)
        {
            Panel panel = new Panel();
            panel.Size = new Size(220, 380);
            panel.BackColor = Color.FromArgb(60, 60, 60);
            panel.Margin = new Padding(10);

            // --- Постер ---
            PictureBox pic = new PictureBox();
            pic.Size = new Size(200, 200);
            pic.Location = new Point(10, 10);
            if (!string.IsNullOrEmpty(movie.PosterPath) && File.Exists(movie.PosterPath))
                pic.Image = Image.FromFile(movie.PosterPath);
            else
                pic.Image = new Bitmap(200, 200);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(pic);

            // --- Название ---
            Label lblTitle = new Label();
            lblTitle.Text = movie.Title;
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Arial", 10, FontStyle.Bold);
            lblTitle.Location = new Point(10, 215);
            lblTitle.Size = new Size(200, 20);
            panel.Controls.Add(lblTitle);

            // --- Жанр + Год ---
            Label lblGenreYear = new Label();
            lblGenreYear.Text = $"{movie.Genre} | {movie.Year}";
            lblGenreYear.ForeColor = Color.LightGray;
            lblGenreYear.Font = new Font("Arial", 9, FontStyle.Regular);
            lblGenreYear.Location = new Point(10, 235);
            lblGenreYear.Size = new Size(200, 20);
            panel.Controls.Add(lblGenreYear);

            // --- Рейтинг + Статус ---
            Label lblRatingStatus = new Label();
            lblRatingStatus.Text = $"Рейтинг: {movie.Rating} | {movie.Status}";
            lblRatingStatus.ForeColor = Color.LightGray;
            lblRatingStatus.Font = new Font("Arial", 9, FontStyle.Regular);
            lblRatingStatus.Location = new Point(10, 255);
            lblRatingStatus.Size = new Size(200, 20);
            panel.Controls.Add(lblRatingStatus);

            // --- Описание ---
            TextBox txtDesc = new TextBox();
            txtDesc.Text = movie.Description;
            txtDesc.Location = new Point(10, 275);
            txtDesc.Size = new Size(200, 50);
            txtDesc.Multiline = true;
            txtDesc.ReadOnly = true;
            txtDesc.BackColor = Color.FromArgb(60, 60, 60);
            txtDesc.ForeColor = Color.White;
            txtDesc.BorderStyle = BorderStyle.None;
            txtDesc.ScrollBars = ScrollBars.Vertical;
            panel.Controls.Add(txtDesc);

            // --- Прогресс для сериалов ---
            int buttonTop = 330;
            if (movie.IsSeries && movie.TotalEpisodes > 0)
            {
                ProgressBar progress = new ProgressBar();
                progress.Location = new Point(10, 330);
                progress.Size = new Size(200, 10);
                progress.Minimum = 0;
                progress.Maximum = movie.TotalEpisodes;
                progress.Value = Math.Min(movie.CurrentEpisode, movie.TotalEpisodes);
                panel.Controls.Add(progress);

                Label lblProgress = new Label();
                lblProgress.Text = $"Смотрю {movie.CurrentEpisode}/{movie.TotalEpisodes} серий";
                lblProgress.ForeColor = Color.LightGray;
                lblProgress.Font = new Font("Arial", 8, FontStyle.Regular);
                lblProgress.Location = new Point(10, 345);
                lblProgress.Size = new Size(200, 15);
                panel.Controls.Add(lblProgress);

                buttonTop = 360;
            }

            // --- Кнопка Редактировать ---
            Button btnEdit = new Button();
            btnEdit.Text = "Редактировать";
            btnEdit.BackColor = Color.FromArgb(0, 122, 204);
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Arial", 8);
            btnEdit.Size = new Size(95, 25);
            btnEdit.Location = new Point(10, buttonTop);
            btnEdit.Click += (s, e) =>
            {
                AddEditForm form = new AddEditForm(movieRepository, movie);
                form.ShowDialog();
                LoadMovies();
            };
            panel.Controls.Add(btnEdit);

            // --- Кнопка Удалить ---
            Button btnDelete = new Button();
            btnDelete.Text = "Удалить";
            btnDelete.BackColor = Color.FromArgb(200, 50, 50);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Arial", 8);
            btnDelete.Size = new Size(95, 25);
            btnDelete.Location = new Point(115, buttonTop);
            btnDelete.Click += (s, e) =>
            {
                var result = MessageBox.Show("Удалить фильм?", "Подтвердить", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    movieRepository.Delete(movie);
                    LoadMovies();
                }
            };
            panel.Controls.Add(btnDelete);

            return panel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditForm form = new AddEditForm(movieRepository);
            if (form.ShowDialog() == DialogResult.OK)
                LoadMovies();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMovies();
        }
    }
}
