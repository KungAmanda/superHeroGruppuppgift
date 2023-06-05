using System.ComponentModel.DataAnnotations;

namespace superHeroGruppuppgift.Models
{
    public class superHeroTeam
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Headquarters { get; set; }

        public ICollection<superHeros> superHeros { get; set; }
    }
}
