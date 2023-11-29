using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestWebshop.Data;
using TestWebshop.Models;
using TestWebshop.Models.Database;

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
            return View();
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


    }
}