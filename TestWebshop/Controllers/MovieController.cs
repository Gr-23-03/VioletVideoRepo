using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        //public IActionResult Index()
        //{
        //    //List<Movie> objList = new List<Movie>();
        //    var objList = _db.Movies.ToList();

        //    return View(objList);
        //}

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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.Movies == null)
            {
                return NotFound();
            }

            var movie = await _db.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.Movies == null)
            {
                return NotFound();
            }

            var movie = await _db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Director,ReleaseYear,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
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
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        private bool MovieExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.Movies == null)
            {
                return NotFound();
            }

            var movie = await _db.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.Movies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
            }
            var movie = await _db.Movies.FindAsync(id);
            if (movie != null)
            {
                _db.Movies.Remove(movie);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool MovieExists(int id)
        //{
        //    return _db.Movies.Any(e => e.Id == id);
        //}
    }
}


//public IActionResult Import()
//        {
//            return View();
//        }




//        [HttpPost]
//        public async Task<IActionResult> Import(string query)
//        {
//            var movies = await _movieService.SearchOmdb(query);
//            return View(movies);
//        }

//        public async Task<IActionResult> ImportImdb(string imdb)
//        {
//            var movies = await _movieService.OmdbSearch(imdb);
//            return View(movies);
//        }


//    }
//}