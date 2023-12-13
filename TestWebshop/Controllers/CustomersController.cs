using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestWebshop.Data;
using TestWebshop.Models;
using TestWebshop.Models.Database;
using TestWebshop.Models.ViewModels;

namespace TestWebshop.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Customers
        //public async Task<IActionResult> Index()
        //{
        //    return _context.Customers != null ?
        //                View(await _context.Customers.ToListAsync()) :
        //                Problem("Entity set 'ApplicationDbContext.Customers'  is null.");
        //}

        //public async Task<IActionResult> Index(string searchString = null, int pg = 1)
        //{
        //    var customers = from c in _context.Customers
        //                    select c;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        customers = customers.Where(c => c.Name.Contains(searchString));
        //    }

        //    var customerViewModel = new CustomerViewModel
        //    {
        //        Customers = await customers.ToListAsync(),
        //    };

        //    const int pageSize = 3;

        //    if (pg < 1)
        //        pg = 1;

        //    int recsCount = customers.Count();

        //    var pager = new Pager(recsCount, pg, pageSize);

        //    int recSkip = (pg - 1) * pageSize;

        //    customerViewModel.Customers = customers.Skip(recSkip).Take(pager.PageSize).ToList();
        //    customerViewModel.Pager = pager;

        //    return View(customerViewModel);
        //}



        public async Task<IActionResult> Index(string searchString = null, int pg = 1)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Customers' is null.");
            }

            var customers = from c in _context.Customers
                            select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c => c.FirstName.Contains(searchString));
            }

            var customerViewModel = new CustomerViewModel
            {
                customers = await customers.ToListAsync(),

            };

           var CustomerViewModel = new CustomerViewModel();
            customerViewModel.customers = await customers.ToListAsync();



            const int pageSize = 3;

            if (pg < 1)
                pg = 1;

            int recsCount = customers.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            customerViewModel.customers = customers.Skip(recSkip).Take(pager.PageSize).ToList();
            customerViewModel.pager = pager;

            return View(customerViewModel);

        }









        public IActionResult AllCustomers()
        {
            var customers = _context.Customers.ToList(); 
            return View(customers);
        }






        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        
        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,BillingAddress,BillingCity,BillingZip,DeliveryAddress,DeliveryCity,DeliveryZip,EmailAddress,Phone")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Customers'  is null.");
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }






        [Route("Customers/AllOrders/{email}")]
        public IActionResult AllOrders(string email)
        {
            

            var customerInfo = _context.Customers
                .Where(c => c.EmailAddress == email)
                .Select(c => new { c.Id, FullName = c.FirstName + " " + c.LastName })
                .FirstOrDefault();

            if (customerInfo == null)
            {
                return NotFound();
            }

            ViewData["Name"] = customerInfo.FullName;

            var orders = _context.Orders
                .Where(o => o.CustomerId == customerInfo.Id)
                .ToList();

            var jointbl = from o in orders
                          join or in _context.OrderRows on o.Id equals or.OrderId
                          join m in _context.Movies on or.MovieId equals m.Id
                          select new { Date = o.OrderDate, Price = or.Price, Movie = m };

            var query = from o in jointbl
                        group o by o.Date into grp
                        select new CustomerOrder()
                        {
                            Date = grp.Key,
                            Total = grp.Sum(o => o.Price),
                            Movies = grp.Select(o => o.Movie).ToList()
                        };

            return View(query);
        }


        private bool CustomerExists(int id)
        {
          return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
