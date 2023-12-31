﻿using DeliveryParcel.Data;
using DeliveryParcel.Data.Interface;
using DeliveryParcel.Models;
using DeliveryParcel.Service.Interfaces;

namespace DeliveryParcel.Service.Infrastructure
{
    public class ClientService : IClientService
    {
        private readonly IBaseRepository<Client> _clientRepository;
        public ClientService(IBaseRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<OperationResponse<Guid>> CreateClientAsync(ClientVm clientVm)
        {
            var client = new Client
            {
                FirstName = clientVm.FirstName,
                LastName = clientVm.LastName,
                CreatedDate = DateTime.UtcNow,
            };
            await _clientRepository.AddEntityAsync(client);
            return new OperationResponse<Guid> { IsSuccess = true, Result = client.Id };
        }
        public async Task<OperationResponse<Guid>> GetClientIdAsync(ClientVm clientVm)
        {
            var normFirstName = string.Join(" ", clientVm.FirstName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToUpper();
            var normLastName = string.Join(" ", clientVm.LastName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToUpper();
            var client = await _clientRepository.GetEnttyOrDeafaultAsync(c => c.FirstName.ToUpper() == normFirstName &&
                                                                              c.LastName.ToUpper() == normLastName);
            if (client is null)
                return new OperationResponse<Guid> { IsSuccess = false };

            return new OperationResponse<Guid> { IsSuccess = true, Result = client.Id };
        }
    }
}
