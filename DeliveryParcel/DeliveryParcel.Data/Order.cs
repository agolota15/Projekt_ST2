using System.ComponentModel.DataAnnotations;

namespace DeliveryParcel.Data
{
    public class Order : BaseEntity
    {
        public Guid SenderId { get; set; }
        public Guid SenderAddressId { get; set; }
        public Guid RecipientId { get; set; }
        public Guid RecipientAddressId { get; set; }
        public Guid ParcelId { get; set; }
        public DateTime ShippingDate { get; set; }
        public Client Sender { get; set; } = null!;
        public Client Recipient { get; set; } = null!;
        public Parcel Parcel { get; set; } = null!;
        public Address SenderAddress { get; set; } = null!;
        public Address RecipientAddress { get; set; } = null!;
    }
}
