using AutoMapper;
using DeliveryParcel.Data;
using DeliveryParcel.Models;

namespace DeliveryParcel.Service.Infrastructure.MapperConfiguration
{
    public class OrderConverter : ITypeConverter<Order, OrderVm>
    {
        public OrderVm Convert(Order source, OrderVm destination, ResolutionContext context)
        {
            destination ??= new OrderVm();

            destination.ShippingDate = source.ShippingDate;
            destination.Id = source.Id;
            destination.SenderFullName = GetSenderFullName(source);
            destination.SenderFullAddress = GetSenderFullAddress(source);
            destination.SenderCity = source.SenderAddress.City.Name;
            destination.RecipientFullName = GetRecipientFullName(source);
            destination.RecipientFullAddress = GetRecipientFullAddress(source);
            destination.RecipientCity = source.RecipientAddress.City.Name;
            destination.ParcelWeight = source.Parcel.Weight.ToString() + " kg";

            return destination;
        }

        private static string GetSenderFullName(Order source)
        {
            var fullName = source.Sender.LastName + " " + source.Sender.FirstName;
            return fullName;
        }
            

        private static string GetSenderFullAddress(Order source)
        {
            var senderFullAddress = "ul. " + source.SenderAddress.Street + " " + source.SenderAddress.House;
            if (!string.IsNullOrEmpty(source.SenderAddress.Appartament))
                senderFullAddress += "/" + source.SenderAddress.Appartament;

            return senderFullAddress;
        }

        private static string GetRecipientFullName(Order source)
        {
            var fullName = source.Recipient.LastName + " " + source.Recipient.FirstName;
            return fullName;
        }
             

        private static string GetRecipientFullAddress(Order source)
        {
            var recipientFullAddress = "ul. " + source.SenderAddress.Street + " " + source.SenderAddress.House;
            if (!string.IsNullOrEmpty(source.SenderAddress.Appartament))
                recipientFullAddress += "/" + source.SenderAddress.Appartament;

            return recipientFullAddress;
        }
    }
}
