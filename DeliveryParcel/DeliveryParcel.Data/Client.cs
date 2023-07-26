using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryParcel.Data
{
    public class Client : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        [NotMapped]
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
