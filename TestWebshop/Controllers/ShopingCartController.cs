using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestWebshop.Data;
using TestWebshop.Models.Database;

namespace TestWebshop.Controllers
{
    public class ShopingCartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopingCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShopingCart
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderRows.Include(o => o.Movie).Include(o => o.Order);
            return View(await applicationDbContext.ToListAsync());
        }




        















        // GET: ShopingCart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderRows == null)
            {
                return NotFound();
            }

            var orderRow = await _context.OrderRows
                .Include(o => o.Movie)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderRow == null)
            {
                return NotFound();
            }

            return View(orderRow);
        }

        // GET: ShopingCart/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            return View();
        }

        // POST: ShopingCart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,MovieId,Price")] OrderRow orderRow)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(orderRow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", orderRow.MovieId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderRow.OrderId);
            return View(orderRow);
        }

        // GET: ShopingCart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderRows == null)
            {
                return NotFound();
            }

            var orderRow = await _context.OrderRows.FindAsync(id);
            if (orderRow == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Director", orderRow.MovieId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderRow.OrderId);
            return View(orderRow);
        }

        // POST: ShopingCart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,MovieId,Price")] OrderRow orderRow)
        {
            if (id != orderRow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderRow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderRowExists(orderRow.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Director", orderRow.MovieId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderRow.OrderId);
            return View(orderRow);
        }

        // GET: ShopingCart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderRows == null)
            {
                return NotFound();
            }

            var orderRow = await _context.OrderRows
                .Include(o => o.Movie)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderRow == null)
            {
                return NotFound();
            }

            return View(orderRow);
        }

        // POST: ShopingCart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderRows == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OrderRows'  is null.");
            }
            var orderRow = await _context.OrderRows.FindAsync(id);
            if (orderRow != null)
            {
                _context.OrderRows.Remove(orderRow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderRowExists(int id)
        {
          return (_context.OrderRows?.Any(e => e.Id == id)).GetValueOrDefault();
        }







        public IActionResult AddToCart (int id)
        {

            //Mor code for addingcart to season
            return RedirectToAction("Details", "Orders");
        }
    }
}
