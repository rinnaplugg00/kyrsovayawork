using System.Collections.Generic;
using System.Linq;
using MovieCatalog.Models;

namespace MovieCatalog.Helpers
{
    public static class RecommendationEngine
    {
        public static List<Movie> GetRecommendations(List<Movie> allMovies, Movie currentMovie, int count = 5)
        {
            if (currentMovie == null) return new List<Movie>();

            return allMovies
                .Where(m => m.Genre == currentMovie.Genre && m.Title != currentMovie.Title)
                .OrderByDescending(m => double.TryParse(m.Rating, out var r) ? r : 0)
                .Take(count)
                .ToList();
        }
    }
}
