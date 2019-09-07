using System.ComponentModel.DataAnnotations;

namespace TourOfHeroes.Web.Components.Heroes.State
{
    public class Hero
    {
        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
    }
}