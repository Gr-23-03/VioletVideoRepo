using Microsoft.AspNetCore.Mvc.Rendering;
using TestWebshop.Models.Database;

namespace TestWebshop.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie> movies;
        public SelectList genres;
        public string movieGenre { get; set; }


    }
}
