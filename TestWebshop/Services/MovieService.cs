using Newtonsoft.Json.Linq;
using TestWebshop.Data;
using TestWebshop.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TestWebshop.Services
{
    public class MovieService : IMovieService
    {
        string apiKey = "8c11ae5f";
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _db;

        public MovieService(HttpClient httpClient, ApplicationDbContext db)
        {
            _httpClient = httpClient;
            _db = db;
        }

        public async Task<List<MovieViewModel>> SearchOmdb(string query)
        {
            var response = await _httpClient.GetAsync($"https://www.omdbapi.com/?s={query}&type=Movie&apikey={apiKey}");
            var searchResponse = await response.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(searchResponse);
            var movies = jsonObject["Search"].ToObject<List<MovieViewModel>>();

            return movies;
        }

        public async Task<MovieViewModel> OmdbSearch(string imdb)
        {
            var response = await _httpClient.GetAsync($"https://www.omdbapi.com/?i={imdb}&apikey={apiKey}");
            var searchRespons = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(searchRespons);
            var movies = jsonObject.ToObject<MovieViewModel>();
            
            return movies;

        }

    }


}
