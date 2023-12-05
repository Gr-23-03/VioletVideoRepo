using Microsoft.AspNetCore.Mvc.Rendering;
using TestWebshop.Models.Database;
using TestWebshop.Models.ViewModels;

namespace TestWebshop.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie> movies;
        public SelectList genres;
        public string movieGenre { get; set; }
        public List<DisplayCartVM> CartItems { get; set; }



    }
}
