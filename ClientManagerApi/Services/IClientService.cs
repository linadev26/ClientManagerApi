using ClientManagerApi.Dtos;

namespace ClientManagerApi.Services
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetClientsAsync(int userId);
        Task<ClientDto> CreateClientAsync(ClientDto clientDto, int userId);
        Task<ClientDto?> GetClientByIdAsync(int clienteId, int userId);
    }
}
