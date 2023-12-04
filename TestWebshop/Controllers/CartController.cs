using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebshop.Data;
using TestWebshop.Extensions;
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
                var mObj = _context.Movies.Find(item);




            }

            return View(cartMovieDistinctList);
        }

        public IActionResult AddToCart(int movieId)
        {
            var cartList = HttpContext.Session.Get<List<int>>("cartSessionKey") ?? new List<int>();
            cartList.Add(movieId);
            HttpContext.Session.Set<List<int>>(cartSessionKey, cartList);
            return RedirectToAction("Index", "Movie");


            return View();
        }


    }
}
