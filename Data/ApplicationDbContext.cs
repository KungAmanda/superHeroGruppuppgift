using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using superHeroGruppuppgift.Models;

namespace superHeroGruppuppgift.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        internal object superHeroTeams;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<superHeros> superHeros { get; set; }

        public DbSet<superHeroTeam> superHeroTeam { get; set; }

      

    }
}