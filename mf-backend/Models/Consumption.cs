using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_backend.Models
{
    [Table("Consumptions")]
    public class Consumption
    {
        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Value is required")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Mileage is required")]
        public int Km { get; set; }

        [Display(Name = "Fuel Type")]
        public FuelType FuelType { get; set; }

        [Display(Name = "Vehicle")]
        [Required(ErrorMessage = "Vehicle is required")]
        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }
    }

        public enum FuelType 
        {
            Gasoline,
            Ethanol,
            Diesel,
            Flex
        }

}
