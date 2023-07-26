using System.ComponentModel.DataAnnotations;

namespace DeliveryParcel.Models
{
    public class OrderVm
    {
        [Display(Name = "ID")]
        public Guid Id { get; set; }
        [Display(Name = "Imię Nazwisko nadawcy")]
        public string SenderFullName { get; set; } = null!;
        [Display(Name = "Adres nadawcy")]
        public string SenderFullAddress { get; set; } = null!;
        [Display(Name = "Miasto nadawcy")]
        public string SenderCity { get; set; } = null!;
        [Display(Name = "Imię Nazwisko odbiorcy")]
        public string RecipientFullName { get; set; } = null!;
        [Display(Name = "Adres odbiorcy")]
        public string RecipientFullAddress { get; set; } = null!;
        [Display(Name = "Miasto odbiorcy")]
        public string RecipientCity { get; set; } = null!;
        [Display(Name = "Waga przesyłki")]
        public string ParcelWeight { get; set; } = null!;
        [Display(Name = "Data wysyłki")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime ShippingDate { get; set; }
    }
}
