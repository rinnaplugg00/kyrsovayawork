using System;
using System.Drawing;
using System.Windows.Forms;
using MovieCatalog.Models;
using MovieCatalog.Helpers;

namespace MovieCatalog.Forms
{
    public partial class MovieCard : UserControl
    {
        public Movie MovieData { get; private set; }
        public event EventHandler EditClicked;

        public MovieCard(Movie movie)
        {
            InitializeComponent();
            MovieData = movie;
            InitCard();
        }

        private void InitCard()
        {
            picPoster.Image = ImageHelper.LoadPoster(MovieData.PosterPath, 150, 200);
            lblTitle.Text = MovieData.Title;
            lblGenre.Text = MovieData.Genre;
            lblRating.Text = MovieData.Rating;
            lblStatus.Text = MovieData.Status;
            lblDescription.Text = MovieData.Description.Length > 100
                ? MovieData.Description.Substring(0, 100) + "..."
                : MovieData.Description;

            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
