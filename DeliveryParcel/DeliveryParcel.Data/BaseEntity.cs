using System.Data.SqlTypes;

namespace DeliveryParcel.Data
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
