using System.ComponentModel.DataAnnotations;

namespace Pub.Models.ViewModels
{
    public class BeerViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public int BrandId { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public string Name { get; set; }
    }
}
