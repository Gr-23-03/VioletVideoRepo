using Microsoft.AspNetCore.Mvc.Rendering;
using TestWebshop.Models.Database;

namespace TestWebshop.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie> movies { get; set; }
        public SelectList genres;
        public string movieGenre { get; set; }
        public Pager pager { get; set; }


    }
}
