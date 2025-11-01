using MovieCatalog.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; // используем только Newtonsoft.Json

namespace MovieCatalog.Services
{
    public class MovieRepository
    {
        private string filePath;
        private List<Movie> movies;

        public MovieRepository(string path)
        {
            filePath = path;

            if (!File.Exists(filePath))
            {
                movies = new List<Movie>();
                Save();
            }
            else
            {
                string json = File.ReadAllText(filePath);
                movies = JsonConvert.DeserializeObject<List<Movie>>(json) ?? new List<Movie>();
            }
        }

        public List<Movie> GetAll()
        {
            return movies;
        }

        public void Add(Movie movie)
        {
            movies.Add(movie);
            Save();
        }

        public void Update(Movie movie)
        {
            var existing = movies.Find(m => m.Title == movie.Title);
            if (existing != null)
            {
                existing.Genre = movie.Genre;
                existing.Status = movie.Status;
                existing.Description = movie.Description;
                existing.PosterPath = movie.PosterPath;
                existing.Rating = movie.Rating;
                Save();
            }
        }

        public void Delete(Movie movie)
        {
            movies.Remove(movie);
            Save();
        }

        private void Save()
        {
            // Явно указываем Newtonsoft.Json.Formatting, чтобы не было конфликта
            string json = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
