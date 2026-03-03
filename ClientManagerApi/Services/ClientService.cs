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

        public async Task<List<ClientDto>> GetClientsAsync()
        {
            var clients = await _repository.GetAll();

            return clients.Select(c => new ClientDto
            {
                Name = c.Name,
                Email = c.Email
            }).ToList();
        }

        public async Task<ClientDto> CreateClientAsync(ClientDto clientDto)
        {
            if (string.IsNullOrWhiteSpace(clientDto.Name))
                throw new Exception("Client name is required");

            var client = new Client
            {
                Name = clientDto.Name.Trim(),
                Email = clientDto.Email.Trim(),
                Phone = ""
            };

            var created = await _repository.Add(client);

            return new ClientDto
            {
                Name = created.Name,
                Email = created.Email
            };
        }

        public async Task<ClientDto?> GetClientByIdAsync(int clienteId)
        {
            var cliente = await _repository.GetClientById(clienteId);

            if(cliente == null)
            {
                return null;
            }

            return new ClientDto { Name = cliente.Name, Email = cliente.Email };
        }
    }
}
