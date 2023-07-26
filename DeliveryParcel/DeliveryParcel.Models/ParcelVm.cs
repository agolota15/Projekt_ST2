using System.ComponentModel.DataAnnotations;

namespace DeliveryParcel.Models
{
    public class ParcelVm
    {
        [Required(ErrorMessage = "Wymagane pole.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Minimalna waga 0.1 kg.")]
        [Display(Name = "Waga przesyłki")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Wieght { get; set; }
    }
}
