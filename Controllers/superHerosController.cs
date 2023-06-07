using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using superHeroGruppuppgift.Data;
using superHeroGruppuppgift.Models;

namespace superHeroGruppuppgift.Controllers
{
    public class superHerosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public superHerosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: superHeros
        public async Task<IActionResult> Index(string SearchString)
        {

            // return _context.superHeros != null ? 
            //View(await _context.superHeros.ToListAsync()) :
             Problem("Entity set 'ApplicationDbContext.superHeros'  is null.");
            ViewData["CurrentFilter"] = SearchString;
            var superHeros = from b in _context.superHeros select b;
            if (!String.IsNullOrEmpty(SearchString))
            {
                superHeros = superHeros.Where(b => b.Name.Contains(SearchString));
            }
            return View(superHeros);
            if (!String.IsNullOrEmpty(SearchString))
            {
                superHeros = superHeros.Where(b => b.Lastname.Contains(SearchString));
            }
            return View(superHeros);
        }

    // GET: superHeros/Details/5
    public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.superHeros == null)
            {
                return NotFound();
            }

            var superHeros = await _context.superHeros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superHeros == null)
            {
                return NotFound();
            }

            return View(superHeros);
        }

        // GET: superHeros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: superHeros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Lastname,HeroName,Superpower")] superHeros superHeros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superHeros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superHeros);
        }

        // GET: superHeros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.superHeros == null)
            {
                return NotFound();
            }

            var superHeros = await _context.superHeros.FindAsync(id);
            if (superHeros == null)
            {
                return NotFound();
            }
            return View(superHeros);
        }

        // POST: superHeros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Lastname,HeroName,Superpower")] superHeros superHeros)
        {
            if (id != superHeros.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superHeros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!superHerosExists(superHeros.Id))
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
            return View(superHeros);
        }

        // GET: superHeros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.superHeros == null)
            {
                return NotFound();
            }

            var superHeros = await _context.superHeros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superHeros == null)
            {
                return NotFound();
            }

            return View(superHeros);
        }

        // POST: superHeros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.superHeros == null)
            {
                return Problem("Entity set 'ApplicationDbContext.superHeros'  is null.");
            }
            var superHeros = await _context.superHeros.FindAsync(id);
            if (superHeros != null)
            {
                _context.superHeros.Remove(superHeros);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool superHerosExists(int id)
        {
          return (_context.superHeros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
