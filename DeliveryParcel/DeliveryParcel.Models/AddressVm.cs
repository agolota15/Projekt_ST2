using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeliveryParcel.Models
{
    public class AddressVm
    {
        [Required(ErrorMessage = "Wymagane pole.")]
        [Display(Name = "Miasto")]
        public string CityName { get; set; } = null!;
        [Required(ErrorMessage = "Wymagane pole.")]
        [Display(Name = "Ulica")]
        public string Street { get; set; } = null!;
        [Required(ErrorMessage = "Wymagane pole.")]
        [Display(Name = "Budynek")]
        public string House { get; set; } = null!;
        [Display(Name = "Mieszkanie")]
        public string? Appartament { get; set; }
    }
}
