using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var cartMovieDistinctList = GetCartItems();

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
            var cartMovieDistinctList = GetCartItems();
            return Json(cartMovieDistinctList);
        }



        public IActionResult RemoveFromCart(int Id)
        {
            {
                var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>();

                if (cartList.Contains(Id))
                {
                    cartList.Remove(Id);
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


        }

        public IActionResult UpdateCart(int movieId, int quantityDelta)
        {
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>();

            // Check if the movieId is in the cart
            if (cartList.Contains(movieId))
            {
                // Update the quantity based on quantityDelta
                int index = cartList.IndexOf(movieId);

                if (quantityDelta > 0)
                {
                    // Increment the quantity (add copies)
                    for (int i = 0; i < quantityDelta; i++)
                    {
                        cartList.Add(movieId);
                    }
                }
                else if (quantityDelta < 0)
                {
                    // Decrement the quantity (remove copies)
                    for (int i = 0; i < -quantityDelta; i++)
                    {
                        cartList.Remove(movieId);
                    }
                }

                HttpContext.Session.Set<List<int>>("ShoppingCart", cartList);
            }

            return RedirectToAction("GetCartContent");
        }

        public IActionResult Checkout()
        {
            var cartItems = GetCartItems();
            return View(cartItems);
        }

        [HttpPost]
        public IActionResult Checkout(string email)
        {
            // check if a customer with given email exists...

            // if it exist, get cart items and create an order and then redirect to order complete view

            // otherwise redirect to create customer view

            return RedirectToAction("Checkout");
        }

        private List<DisplayCartVM> GetCartItems()
        {
            var cartItemIds = HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>();

            var cartItems = new List<DisplayCartVM>();

            foreach (var group in cartItemIds.GroupBy(x => x))
            {
                // Use the Find method to get the movie object
                var mObj = _context.Movies.Find(group.Key);

                // Check if mObj is not null before accessing its properties
                if (mObj != null)
                {
                    var obj = new DisplayCartVM
                    {
                        Id = mObj.Id,
                        PictureUrl = mObj.ImageURL,
                        Price = mObj.Price,
                        Title = mObj.Title,
                        Quantity = group.Count()
                    };

                    cartItems.Add(obj);
                }
            }

            return cartItems;
        }

        //// Create an order
        //var order = CreateOrder(userId);

        //// Create order rows for each item in the shopping cart
        //foreach (var movieId in HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>())
        //{
        //    CreateOrderRow(order.Id, movieId);
        //}

        //// Clear the shopping cart
        //HttpContext.Session.Remove("ShoppingCart");

        //// Redirect to the confirmation page or wherever you want to go after checkout
        //return RedirectToAction("CheckoutConfirmation");
    }


}





