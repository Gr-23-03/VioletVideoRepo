using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Drawing.Printing;
using TestWebshop.Data;
using TestWebshop.Models;
using TestWebshop.Models.Database;
using TestWebshop.Services;

namespace TestWebshop.Controllers
{

    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public ApplicationDbContext _db;
        public MovieController(IMovieService MovieService, ApplicationDbContext db)
        {
            _movieService = MovieService;
            _db = db;
        }



        ////public IActionResult Index()
        ////{
        ////    //List<Movie> objList = new List<Movie>();
        ////    var objList = _db.Movies.ToList();

        ////    return View(objList);
        ////}



        

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();

        }


        // POST: Movies/Create

       [HttpPost]
         public IActionResult Create(Movie obj)
        {
            _db.Movies.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Movies

        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            //  LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _db.Movies
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _db.Movies
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            var movieGenreVM = new MovieGenreViewModel();
            movieGenreVM.genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            movieGenreVM.movies = await movies.ToListAsync();

            return View(movieGenreVM);
        }


        // GET: Movies/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _db.Movies
                .SingleOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }



        //Edit
        //GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _db.Movies.SingleOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Director,ReleaseYear,Price,Genre,ImageURL")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _db.Update(movie);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(movie);
        }


    


        // Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _db.Movies
                .SingleOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }


        // POST: Movies/Delete

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _db.Movies.SingleOrDefaultAsync(m => m.Id == id);
            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MovieExists(int id)
        {
            return _db.Movies.Any(e => e.Id == id);
        }






        //shop movies

      


        //popular

        public ActionResult PopularMovies()
        {
            var populars = from OrderRow in _db.OrderRows
                           group OrderRow by OrderRow.MovieId into action
                           select new { count = action.Count(), key = action.Key };
            IDictionary<int, int> Movie = new Dictionary<int, int>();
            List<Movie> PopularMovies = new List<Movie>();
            foreach (var movie in populars)
            {
                Movie.Add(movie.key, movie.count);
            }

            var sorted = from sortedMovies in Movie
                         orderby sortedMovies.Value descending
                         select sortedMovies;


            foreach (var item in sorted)
            {
                var it = _db.Movies.Find(item.Key);
                PopularMovies.Add(it);
            }

            return View(PopularMovies.ToList());
        }









        //Oldest

        public ActionResult OldestMovies()
        {

            var oldest = _db.Movies.OrderBy(obj => obj.ReleaseYear).ToList();
            //return View(_db.Movies.ToList());
            return View(oldest);
        }



        public ActionResult LatestMovies()
        {

            var latest = _db.Movies.OrderByDescending(obj => obj.ReleaseYear).ToList();
            return View(latest);
            
        }


        public ActionResult CheapestMovies()
        {

            var cheapest = _db.Movies.OrderBy(obj => obj.Price).ToList();
            //return View(_db.Movies.ToList());
            return View(cheapest);
        }








        public IActionResult Import()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Import(string query)
        {
            var movies = await _movieService.SearchOmdb(query);
            return View(movies);
        }

        public async Task<IActionResult> ImportImdb(string imdb)
        {
            var movies = await _movieService.OmdbSearch(imdb);
            return View(movies);
        }





    }


}