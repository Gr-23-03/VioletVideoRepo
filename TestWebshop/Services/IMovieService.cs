using TestWebshop.Models;

namespace TestWebshop.Services
{
    public interface IMovieService
    {
        Task<List<MovieViewModel>> SearchOmdb(string query);
        Task<MovieViewModel> OmdbSearch(string imdb);
    }
}
