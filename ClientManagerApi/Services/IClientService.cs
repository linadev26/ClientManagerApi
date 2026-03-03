using ClientManagerApi.Dtos;

namespace ClientManagerApi.Services
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetClientsAsync();
        Task<ClientDto> CreateClientAsync(ClientDto clientDto);
        Task<ClientDto?> GetClientByIdAsync(int clienteId);
    }
}
