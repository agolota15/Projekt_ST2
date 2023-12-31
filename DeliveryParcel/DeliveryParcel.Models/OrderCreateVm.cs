﻿using System.ComponentModel.DataAnnotations;

namespace DeliveryParcel.Models
{
    public class OrderCreateVm
    {
        public ClientVm Sender { get; set; } = null!;
        public AddressVm SenderAddress { get; set; } = null!;
        public ClientVm Recipient { get; set; } = null!;
        public AddressVm RecipientAddress { get; set; } = null!;
        public ParcelVm Parcel { get; set; } = null!;
        [Required(ErrorMessage = "Wymagane pole.")]
        [Display(Name = "Data wysyłki")]
        [DataType(DataType.Date)]
        public DateTime ShippingDate { get; set; }
    }
}
