using MovieCatalog.Models;
using MovieCatalog.Services;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MovieCatalog.Forms
{
    public partial class AddEditForm : Form
    {
        private MovieRepository movieRepository;
        private Movie movie;

        public AddEditForm(MovieRepository repo, Movie movie = null)
        {
            this.movieRepository = repo;
            this.movie = movie;

            InitializeComponent();
            LoadMovieData();
        }

        private void chkIsSeries_CheckedChanged(object sender, EventArgs e)
        {
            numCurrentEpisode.Enabled = chkIsSeries.Checked;
            numTotalEpisodes.Enabled = chkIsSeries.Checked;
        }

        private void LoadMovieData()
        {
            if (movie != null)
            {
                txtTitle.Text = movie.Title;

                // Устанавливаем жанры
                foreach (var genre in movie.Genre.Split(','))
                {
                    int index = clbGenre.Items.IndexOf(genre.Trim());
                    if (index >= 0) clbGenre.SetItemChecked(index, true);
                }

                if (decimal.TryParse(movie.Rating, out decimal rating))
                    numRating.Value = Math.Min(Math.Max(rating, numRating.Minimum), numRating.Maximum);
                else
                    numRating.Value = numRating.Minimum;

                cmbStatus.SelectedItem = movie.Status;
                txtDescription.Text = movie.Description;

                if (int.TryParse(movie.Year, out int year))
                    numYear.Value = Math.Min(Math.Max(year, numYear.Minimum), numYear.Maximum);

                chkIsSeries.Checked = movie.IsSeries;
                numCurrentEpisode.Value = Math.Min(movie.CurrentEpisode, numCurrentEpisode.Maximum);
                numTotalEpisodes.Value = Math.Max(movie.TotalEpisodes, numTotalEpisodes.Minimum);

                if (!string.IsNullOrEmpty(movie.PosterPath) && File.Exists(movie.PosterPath))
                    picPoster.Image = LoadImage(movie.PosterPath);
            }
        }

        private Image LoadImage(string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    Image img = Image.FromStream(fs);
                    return new Bitmap(img);
                }
            }
            catch
            {
                return null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название фильма");
                return;
            }

            Movie m = movie ?? new Movie();
            m.Title = txtTitle.Text;
            m.Year = numYear.Value.ToString();

            // Сохраняем жанры через запятую
            m.Genre = string.Join(", ", clbGenre.CheckedItems.Cast<string>());

            m.Rating = numRating.Value.ToString();
            m.Status = cmbStatus.SelectedItem?.ToString() ?? "Не указан";
            m.Description = txtDescription.Text;

            m.IsSeries = chkIsSeries.Checked;
            m.CurrentEpisode = (int)numCurrentEpisode.Value;
            m.TotalEpisodes = (int)numTotalEpisodes.Value;

            if (!Directory.Exists("posters"))
                Directory.CreateDirectory("posters");

            if (picPoster.Image != null)
            {
                string path = Path.Combine("posters", txtTitle.Text + ".png");
                try
                {
                    if (File.Exists(path))
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        File.Delete(path);
                    }
                    using (var bmp = new Bitmap(picPoster.Image))
                        bmp.Save(path);
                    m.PosterPath = path;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось сохранить постер:\n{ex.Message}");
                }
            }

            if (movie == null)
                movieRepository.Add(m);
            else
                movieRepository.Update(m);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnChoosePoster_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Изображения|*.jpg;*.jpeg;*.png";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (picPoster.Image != null)
                    {
                        picPoster.Image.Dispose();
                        picPoster.Image = null;
                    }
                    picPoster.Image = LoadImage(dlg.FileName);
                }
            }
        }
    }
}
