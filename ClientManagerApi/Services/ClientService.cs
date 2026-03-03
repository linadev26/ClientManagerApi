using ClientManagerApi.Dtos;
using ClientManagerApi.Models;
using ClientManagerApi.Repositories;

namespace ClientManagerApi.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClientDto>> GetClientsAsync(int userId)
        {
            var clients = await _repository.GetAll(userId);

            return clients.Select(c => new ClientDto
            {
                Name = c.Name,
                Email = c.Email
            }).ToList();
        }

        public async Task<ClientDto> CreateClientAsync(ClientDto clientDto, int userId)
        {
            if (string.IsNullOrWhiteSpace(clientDto.Name))
                throw new Exception("Client name is required");

            var client = new Client
            {
                Name = clientDto.Name.Trim(),
                Email = clientDto.Email.Trim(),
                Phone = "",
                OwnerUserId = userId
            };

            var created = await _repository.Add(client);

            return new ClientDto
            {
                Name = created.Name,
                Email = created.Email
            };
        }

        public async Task<ClientDto?> GetClientByIdAsync(int clienteId, int userId)
        {
            var cliente = await _repository.GetClientById(clienteId, userId);

            if (cliente == null || cliente.OwnerUserId != userId)
            {
                return null;
            }

            return new ClientDto { Name = cliente.Name, Email = cliente.Email };
        }
    }
}
