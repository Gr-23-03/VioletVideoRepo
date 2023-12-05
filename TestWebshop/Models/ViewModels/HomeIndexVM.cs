using TestWebshop.Models.Database;
using TestWebshop.Services;

namespace TestWebshop.Models.ViewModels
{
    public class HomeIndexVM
    {
        public List<Movie> NewestMovies { get; set; }

        public List<Movie> OldestMovies { get; set; }

        public List<Movie> CheapestMovies { get; set; }

        public List<Movie> MostPopularMovies { get; set; }


        public HomeIndexVM()
        {
                
        }


    }
}
