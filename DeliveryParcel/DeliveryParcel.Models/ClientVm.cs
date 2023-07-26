using System.ComponentModel.DataAnnotations;

namespace DeliveryParcel.Models
{
    public class ClientVm
    {
        [Required(ErrorMessage = "Wymagane pole.")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Wymagane pole.")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; } = null!;
    }
}
