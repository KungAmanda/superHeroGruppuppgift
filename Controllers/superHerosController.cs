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
    public class SuperHerosController : Controller
    {
        private readonly ApplicationDbContext _context;



        public SuperHerosController(ApplicationDbContext context)
        {
            _context = context;
        }



        // Metod för att visa en lista över alla sparade objekt
        public async Task<IActionResult> Index()
        {
            var superHeros = await _context.superHeros.ToListAsync();
            return View(superHeros);
        }



        // Metod för att lägga till ett nytt objekt i databasen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Lastname,HeroName,Superpower")] superHeros superHero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superHero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superHero);
        }
    }
}
