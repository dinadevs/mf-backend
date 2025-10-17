using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_backend.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Model Year is required")]
        public string ModelYear { get; set; }

        [Required(ErrorMessage = "Plate is required")]
        public string Plate { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Factory Year is required")]
        public string FactoryYear { get; set; }
    }
}
