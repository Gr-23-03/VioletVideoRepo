using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebshop.Data;
using TestWebshop.Extensions;
using TestWebshop.Models;
using TestWebshop.Models.Database;
using TestWebshop.Models.ViewModels;

namespace TestWebshop.Controllers
{
    public class CartController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            var cartItemIds = HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>();

            List<DisplayCartVM> cartMovieDistinctList = new List<DisplayCartVM>();

            foreach (var item in cartItemIds)
            {
                int counter = _context.Movies.Count(m => m.Id == item);

                Movie? mObj = _context.Movies.Find(item);

                DisplayCartVM obj = new DisplayCartVM
                {
                    Id = mObj.Id,
                    PictureUrl = mObj.ImageURL,
                    Price = mObj.Price,
                    Title = mObj.Title,
                    Quantity = counter
                };

                cartMovieDistinctList.Add(obj);
            }

            // Populate MovieGenreViewModel
            var movieGenreViewModel = new MovieGenreViewModel
            {
                // Set other properties of the view model...
                CartItems = cartMovieDistinctList
            };

            return View(movieGenreViewModel);
        }


        public IActionResult AddToCart(int id)
        {
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>();
            cartList.Add(id);
            HttpContext.Session.Set<List<int>>("ShoppingCart", cartList);


            return RedirectToAction("Index", "Movie");
        }


        public IActionResult GetCartContent()
        {
            var cartItemIds = HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>();

            List<DisplayCartVM> cartMovieDistinctList = new List<DisplayCartVM>();

            foreach (var item in cartItemIds)
            {
                int counter = _context.Movies.Count(m => m.Id == item);

                // Use the Find method to get the movie object
                Movie? mObj = _context.Movies.Find(item);

                // Check if mObj is not null before accessing its properties
                if (mObj != null)
                {
                    DisplayCartVM obj = new DisplayCartVM
                    {
                        Id = mObj.Id,
                        PictureUrl = mObj.ImageURL,
                        Price = mObj.Price,
                        Title = mObj.Title,
                        Quantity = counter
                    };

                    cartMovieDistinctList.Add(obj);
                }
                else
                {
                    // Handle the case where the movie with the specified Id is not found
                    // You might want to log a message, skip the item, or handle it in another way
                    // For now, let's just log a message
                }
            }

            return Json(cartMovieDistinctList);
        }



        public IActionResult RemoveFromCart(int movieId)
        {
            {
                var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>();

                if (cartList.Contains(movieId))
                {
                    cartList.Remove(movieId);
                    HttpContext.Session.Set<List<int>>("ShoppingCart", cartList);

                    // Optionally, you can perform additional logic here, such as updating totals.

                    return RedirectToAction("Index", "Movie"); // Redirect to the movie index or wherever you want to go.
                }
                else
                {
                    // Handle the case where the movie is not in the cart
                    // You might want to display a message or redirect to an error page
                    return RedirectToAction("Index", "Movie");
                }
            }

            return (View());

        }

    }
}
