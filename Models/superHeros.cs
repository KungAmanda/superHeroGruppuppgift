using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace superHeroGruppuppgift.Models
{
    public class superHeros
    {
        // här lägger vi attribut för superhjältarna som kommer ligga i tabellen sen
       [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string HeroName { get; set; }
        [Required]
        public string Superpower { get; set;}

        public superHeroTeam? superHeroTeam { get; set; }


    }
}
