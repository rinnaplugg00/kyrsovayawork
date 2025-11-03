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
                // Поиск по названию или описанию
                (m.Title.ToLower().Contains(search) || m.Description.ToLower().Contains(search)) &&

                // Проверка жанра (если выбрано "Все" — не фильтруем)
                (genreFilter == "Все" ||
                 (!string.IsNullOrEmpty(m.Genre) && m.Genre.ToLower().Contains(genreFilter.ToLower()))) &&

                // Проверка статуса
                (statusFilter == "Все" ||
                 (!string.IsNullOrEmpty(m.Status) && m.Status.ToLower().Contains(statusFilter.ToLower())))
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
            panel.Size = new Size(220, 440); // увеличенная высота
            panel.Margin = new Padding(10);
            panel.BorderStyle = BorderStyle.FixedSingle;

            // Цвет карточки для просмотренных
            if (!string.IsNullOrEmpty(movie.Status) && movie.Status.ToLower() == "просмотрено")
                panel.BackColor = Color.FromArgb(255, 180, 50, 50); // насыщенный красный
            else
                panel.BackColor = Color.FromArgb(60, 60, 60); // обычный фон

            int padding = 10;
            int contentWidth = panel.Width - padding * 2;

            // --- Постер ---
            PictureBox pic = new PictureBox();
            pic.Size = new Size(contentWidth, 200);
            pic.Location = new Point(padding, padding);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.BorderStyle = BorderStyle.FixedSingle;
            if (!string.IsNullOrEmpty(movie.PosterPath) && File.Exists(movie.PosterPath))
                pic.Image = Image.FromFile(movie.PosterPath);
            else
                pic.Image = new Bitmap(pic.Width, pic.Height);
            panel.Controls.Add(pic);

            int currentY = pic.Bottom + 5;

            // --- Название ---
            Label lblTitle = new Label();
            lblTitle.Text = movie.Title;
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Arial", 10, FontStyle.Bold);
            lblTitle.Location = new Point(padding, currentY);
            lblTitle.Size = new Size(contentWidth, 20);
            panel.Controls.Add(lblTitle);
            currentY = lblTitle.Bottom + 2;

            // --- Жанр + Год ---
            Label lblGenreYear = new Label();
            lblGenreYear.Text = $"{movie.Genre} | {movie.Year}";
            lblGenreYear.ForeColor = Color.WhiteSmoke;
            lblGenreYear.Font = new Font("Arial", 9);
            lblGenreYear.Location = new Point(padding, currentY);
            lblGenreYear.Size = new Size(contentWidth, 18);
            panel.Controls.Add(lblGenreYear);
            currentY = lblGenreYear.Bottom + 2;

            // --- Рейтинг + Статус ---
            Label lblRatingStatus = new Label();
            lblRatingStatus.Text = $"Рейтинг: {movie.Rating} | {movie.Status}";
            lblRatingStatus.ForeColor = Color.WhiteSmoke;
            lblRatingStatus.Font = new Font("Arial", 9);
            lblRatingStatus.Location = new Point(padding, currentY);
            lblRatingStatus.Size = new Size(contentWidth, 18);
            panel.Controls.Add(lblRatingStatus);
            currentY = lblRatingStatus.Bottom + 2;

            // --- Описание ---
            TextBox txtDesc = new TextBox();
            txtDesc.Text = movie.Description;
            txtDesc.Location = new Point(padding, currentY);
            txtDesc.Size = new Size(contentWidth, 60);
            txtDesc.Multiline = true;
            txtDesc.ReadOnly = true;
            txtDesc.BackColor = panel.BackColor;
            txtDesc.ForeColor = Color.White;
            txtDesc.BorderStyle = BorderStyle.None;
            txtDesc.ScrollBars = ScrollBars.Vertical;
            panel.Controls.Add(txtDesc);
            currentY = txtDesc.Bottom + 5;

            // --- Прогресс сериалов ---
            if (movie.IsSeries && movie.TotalEpisodes > 0)
            {
                ProgressBar progress = new ProgressBar();
                progress.Location = new Point(padding, currentY);
                progress.Size = new Size(contentWidth, 10);
                progress.Minimum = 0;
                progress.Maximum = movie.TotalEpisodes;
                progress.Value = Math.Min(movie.CurrentEpisode, movie.TotalEpisodes);
                panel.Controls.Add(progress);

                currentY = progress.Bottom + 2;

                Label lblProgress = new Label();
                lblProgress.Text = $"Смотрю {movie.CurrentEpisode}/{movie.TotalEpisodes} серий";
                lblProgress.ForeColor = Color.WhiteSmoke;
                lblProgress.Font = new Font("Arial", 8);
                lblProgress.Location = new Point(padding, currentY);
                lblProgress.Size = new Size(contentWidth, 15);
                panel.Controls.Add(lblProgress);
                currentY = lblProgress.Bottom + 5;
            }

            // --- Кнопки внизу ---
            int buttonHeight = 30;
            int buttonSpacing = 5;
            int buttonWidth = (contentWidth - buttonSpacing) / 2;
            int buttonsBottomY = panel.Height - padding - buttonHeight;

            Button btnEdit = new Button();
            btnEdit.Text = "Редактировать";
            btnEdit.BackColor = Color.FromArgb(0, 122, 204);
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Arial", 8);
            btnEdit.Size = new Size(buttonWidth, buttonHeight);
            btnEdit.Location = new Point(padding, buttonsBottomY);
            btnEdit.Click += (s, e) =>
            {
                AddEditForm form = new AddEditForm(movieRepository, movie);
                form.ShowDialog();
                LoadMovies();
            };
            panel.Controls.Add(btnEdit);

            Button btnDelete = new Button();
            btnDelete.Text = "Удалить";
            btnDelete.BackColor = Color.FromArgb(200, 50, 50);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Arial", 8);
            btnDelete.Size = new Size(buttonWidth, buttonHeight);
            btnDelete.Location = new Point(padding + buttonWidth + buttonSpacing, buttonsBottomY);
            btnDelete.Click += (s, e) =>
            {
                if (MessageBox.Show("Удалить фильм?", "Подтвердить", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
