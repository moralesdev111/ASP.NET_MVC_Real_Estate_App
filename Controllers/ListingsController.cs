using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealEstateWebsite.Data;
using RealEstateWebsite.Models;

namespace RealEstateWebsite.Controllers
{
    public class ListingsController : Controller
    {
        private readonly RealEstateWebsiteContext _context;

        public ListingsController(RealEstateWebsiteContext context)
        {
            _context = context;
        }

        // GET: Listings
        public async Task<IActionResult> Index(string searchString)
        {
            var listing = from m in _context.Listings
                          select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                listing = listing.Where(s => s.city.Contains(searchString));
            }

            return View(await listing.ToListAsync());
              //return _context.Listings != null ? 
                          //View(await _context.Listings.ToListAsync()) :
                          //Problem("Entity set 'RealEstateWebsiteContext.Listings'  is null.");
        }

        // GET: Listings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Listings == null)
            {
                return NotFound();
            }

            var listings = await _context.Listings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listings == null)
            {
                return NotFound();
            }

            return View(listings);
        }

        // GET: Listings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,houseName,houseCost,address,squaredMetres,city")] Listings listings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listings);
        }

        // GET: Listings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Listings == null)
            {
                return NotFound();
            }

            var listings = await _context.Listings.FindAsync(id);
            if (listings == null)
            {
                return NotFound();
            }
            return View(listings);
        }

        // POST: Listings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,houseName,houseCost,address,squaredMetres,city")] Listings listings)
        {
            if (id != listings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListingsExists(listings.Id))
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
            return View(listings);
        }

        // GET: Listings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Listings == null)
            {
                return NotFound();
            }

            var listings = await _context.Listings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listings == null)
            {
                return NotFound();
            }

            return View(listings);
        }

        // POST: Listings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Listings == null)
            {
                return Problem("Entity set 'RealEstateWebsiteContext.Listings'  is null.");
            }
            var listings = await _context.Listings.FindAsync(id);
            if (listings != null)
            {
                _context.Listings.Remove(listings);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListingsExists(int id)
        {
          return (_context.Listings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
