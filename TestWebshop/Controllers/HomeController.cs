using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestWebshop.Data;
using TestWebshop.Models;
using TestWebshop.Models.Database;
using TestWebshop.Models.ViewModels;

namespace TestWebshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // var mostPopular = _context.OrderRow.............

            var vm = new HomeIndexVM()
            {
                NewestMovies = _context.Movies.OrderByDescending(m => m.ReleaseYear).ThenBy(m => m.Title).Take(5).ToList(),
                CheapestMovies = _context.Movies.OrderBy(m => m.Price).ThenBy(m => m.Title).Take(5).ToList(),
                OldestMovies = _context.Movies.OrderBy(m => m.ReleaseYear).ThenBy(m => m.Title).Take(5).ToList(),
                //MostPopularMovies = mostPopular.ToList()
            };


            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MoviesListOrdered(string orderBy)
        {
            var mList = new List<Movie>();

            if(orderBy == "newest")
            {
               mList = _context.Movies.OrderByDescending(m => m.ReleaseYear).ThenBy(m => m.Title).Take(10).ToList();
            }
            else if(orderBy == "oldest")
            {
                mList = _context.Movies.OrderBy(m => m.ReleaseYear).ThenBy(m => m.Title).Take(10).ToList();
            }
            else
            {

            }

            return View(mList);
        }

        public IActionResult Contact()
        {
            return View();
        }



    }


}
