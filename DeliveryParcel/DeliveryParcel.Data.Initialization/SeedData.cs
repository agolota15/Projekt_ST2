using DeliveryParcel.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DeliveryParcel.Data.Initialization
{
    public static class SeedData
    { 
        public static async Task Initialize(ApplicationDbContext context)
        {
            if (!context.Clients.Any())
                await AddCilentsAsync(context);

            if (!context.Cities.Any())
                await AddCitiesAsync(context);

            if (!context.Addresses.Any())
                await AddAddressesAsync(context);

            if (!context.Parcels.Any())
                await AddParselsAsync(context);

            if (!context.Orders.Any())
                await AddOrdersAsync(context);
        }
        private static async Task AddOrdersAsync(ApplicationDbContext context)
        {
            var orders = new List<Order>
            {
                new Order
                {
                    SenderId = await GetClientIdAsync(context, "Beata"),
                    SenderAddressId = await GetAddressIdAsync(context, "Krakowska"),
                    RecipientId = await GetClientIdAsync(context, "Kacper"),
                    RecipientAddressId = await GetAddressIdAsync(context, "Jana Matejki"),
                    ParcelId = await GetParcelIdAsync(context, 1.5m),
                    ShippingDate = DateTime.Now
                },
                new Order
                {
                    SenderId = await GetClientIdAsync(context, "Jan"),
                    SenderAddressId = await GetAddressIdAsync(context, "Rejtana"),
                    RecipientId = await GetClientIdAsync(context, "Iwona"),
                    RecipientAddressId = await GetAddressIdAsync(context, "Lisa Kuli"),
                    ParcelId = await GetParcelIdAsync(context, 2.0m),
                    ShippingDate = DateTime.Now
                },
            };
            await context.Orders.AddRangeAsync(orders);
            await context.SaveChangesAsync();
        }
        private static async Task AddParselsAsync(ApplicationDbContext context)
        {
            var parcels = new List<Parcel>
            {
                new Parcel { Weight = 1.5m, CreatedDate = DateTime.UtcNow },
                new Parcel { Weight = 2.0m, CreatedDate = DateTime.UtcNow },
            };
            await context.Parcels.AddRangeAsync(parcels);
            await context.SaveChangesAsync();
        }
        private static async Task AddCilentsAsync(ApplicationDbContext context)
        {
            var clients = new List<Client>
                {
                    new Client { FirstName = "Iwona", LastName = "Boroń" },
                    new Client { FirstName = "Kacper", LastName = "Krupa" },
                };
            await context.Clients.AddRangeAsync(clients);
            await context.SaveChangesAsync();
        }
        private static async Task AddCitiesAsync(ApplicationDbContext context)
        {
            var cities = new List<City>
            {
                new City { Name = "Rzeszów", CreatedDate = DateTime.UtcNow },
                new City { Name = "Kraków", CreatedDate = DateTime.UtcNow },
                new City { Name = "Warszawa", CreatedDate = DateTime.UtcNow },
                new City { Name = "Łódź", CreatedDate = DateTime.UtcNow },
            };
            await context.Cities.AddRangeAsync(cities);
            await context.SaveChangesAsync();
        }
        private static async Task AddAddressesAsync(ApplicationDbContext context)
        {
            var addresses = new List<Address>
            {
                new Address { Street = "Lisa Kuli", House = "44", Appartament = "23", CityId = await GetCityIdAsync(context, "Kraków") },
                new Address { Street = "Jana Matejki", House = "63", Appartament="22", CityId = await GetCityIdAsync(context, "Warszawa") },
                new Address { Street = "Rejtana", House = "22", Appartament = "12", CityId = await GetCityIdAsync(context, "Rzeszów") },
                new Address { Street = "Krakowska", House = "34", Appartament="13", CityId = await GetCityIdAsync(context, "Łódź") },
            };
            await context.Addresses.AddRangeAsync(addresses);
            await context.SaveChangesAsync();
        }
        private static async Task<Guid> GetCityIdAsync(ApplicationDbContext context, string cityName)
        {
            var cities = await context.Cities.FirstAsync(c => c.Name == cityName);
            return cities.Id;
        }
        private static async Task<Guid> GetClientIdAsync(ApplicationDbContext context, string firstName)
        {
            var clients = await context.Clients.FirstAsync(c => c.FirstName == firstName);
            return clients.Id;
        }
        private static async Task<Guid> GetAddressIdAsync(ApplicationDbContext context, string street)
        {
            var addresses = await context.Addresses.FirstAsync(a => a.Street == street);
            return addresses.Id;
        }
        private static async Task<Guid> GetParcelIdAsync(ApplicationDbContext context, decimal weight)
        {
            var parcels = await context.Parcels.FirstAsync(p => p.Weight == weight);
            return parcels.Id;
        }
    }
}