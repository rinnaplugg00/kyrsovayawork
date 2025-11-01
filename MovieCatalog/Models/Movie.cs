namespace MovieCatalog.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string PosterPath { get; set; }
        public bool IsSeries { get; set; } = false;
        public int CurrentEpisode { get; set; }  
        public int TotalEpisodes { get; set; }   



        public Image Poster
        {
            get
            {
                if (!string.IsNullOrEmpty(PosterPath) && File.Exists(PosterPath))
                    return Image.FromFile(PosterPath);
                return null;
            }
        }
    }
}
