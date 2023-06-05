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
    public class superHeroTeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public superHeroTeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: superHeroTeams
        public async Task<IActionResult> Index()
        {
              return _context.superHeroTeam != null ? 
                          View(await _context.superHeroTeam.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.superHeroTeam'  is null.");
        }

        // GET: superHeroTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.superHeroTeam == null)
            {
                return NotFound();
            }

            var superHeroTeam = await _context.superHeroTeam
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superHeroTeam == null)
            {
                return NotFound();
            }

            return View(superHeroTeam);
        }

        // GET: superHeroTeams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: superHeroTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Headquarters")] superHeroTeam superHeroTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superHeroTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superHeroTeam);
        }

        // GET: superHeroTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.superHeroTeam == null)
            {
                return NotFound();
            }

            var superHeroTeam = await _context.superHeroTeam.FindAsync(id);
            if (superHeroTeam == null)
            {
                return NotFound();
            }
            return View(superHeroTeam);
        }

        // POST: superHeroTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Headquarters")] superHeroTeam superHeroTeam)
        {
            if (id != superHeroTeam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superHeroTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!superHeroTeamExists(superHeroTeam.Id))
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
            return View(superHeroTeam);
        }

        // GET: superHeroTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.superHeroTeam == null)
            {
                return NotFound();
            }

            var superHeroTeam = await _context.superHeroTeam
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superHeroTeam == null)
            {
                return NotFound();
            }

            return View(superHeroTeam);
        }

        // POST: superHeroTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.superHeroTeam == null)
            {
                return Problem("Entity set 'ApplicationDbContext.superHeroTeam'  is null.");
            }
            var superHeroTeam = await _context.superHeroTeam.FindAsync(id);
            if (superHeroTeam != null)
            {
                _context.superHeroTeam.Remove(superHeroTeam);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool superHeroTeamExists(int id)
        {
          return (_context.superHeroTeam?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
