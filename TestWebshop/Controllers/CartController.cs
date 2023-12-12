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

            return View();   // view where user put in his/hers email address

        }


        public IActionResult EmailControl(string email)
        {

            // check if email already exist in customer table

            // if exist goto finalCheckout method
            // else goto CreateCustomer

            var existingCustomer = _context.Customers.FirstOrDefault(c => c.EmailAddress == email);

            if (existingCustomer != null)
            {
                // If the email exists, go to the final checkout method
                return RedirectToAction(nameof(FinalCheckout), new { id = existingCustomer.Id });
            }
            else
            {
                // If the email doesn't exist, go to the create customer view
                ViewBag.Email = email; // Pass the email to the CreateCustomer view
                return View("CreateCustomer");
            }
        }


        public IActionResult CreateCustomer()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer obj)
        {
            _context.Customers.Add(obj);
            _context.SaveChanges();

            // find id of this customer with this email address

          
            var customerId = _context.Customers.FirstOrDefault(c => c.EmailAddress== obj.EmailAddress)?.Id;

            return RedirectToAction(nameof(FinalCheckout), new { id = customerId });


        }


        public IActionResult FinalCheckout(int id)  // costomerID
        {
            // save order with custId
            // save orderRows with OrderID


            return View();  // goto Thank You for the order! view
        }


    }
}
