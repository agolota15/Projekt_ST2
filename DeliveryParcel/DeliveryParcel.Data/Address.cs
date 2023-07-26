namespace DeliveryParcel.Data
{
    public class Address : BaseEntity
    {
        public string Street { get; set; } = null!;
        public string House { get; set; } = null!;
        public uint Flat { get; set; }
        public string? Appartament { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; } = null!;
    }
}
