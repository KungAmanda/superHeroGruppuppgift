using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using superHeroGruppuppgift.Data;
using superHeroGruppuppgift.Models;
using System.Diagnostics;
using System.Linq;

namespace superHeroGruppuppgift.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ApplicationDbContext _context { get; set; }
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (!_context.Roles.Any(m => m.Name == "User"))
            {
                await PopulateDB();
            }

            return View();
        }

        private async Task PopulateDB()
        {
            var roleStore = new RoleStore<IdentityRole>(_context);
            var userStore = new UserStore<IdentityUser>(_context);

            string[] roles = { "User" };
            foreach (string role in roles)
            {
                roleStore.CreateAsync(new IdentityRole(role)).Wait();

                var newRole = _context.Roles.Where(m => m.Name == role).FirstOrDefault();
                newRole.NormalizedName = role.ToUpper();

                _context.Roles.Update(newRole);
                await _context.SaveChangesAsync();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


    /*
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }*/
}