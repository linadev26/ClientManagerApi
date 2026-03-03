using ClientManagerApi.Models;

namespace ClientManagerApi.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAll(int userId);
        Task<Client> Add(Client client);
        Task<Client?> GetClientById(int clientId, int userId);
    }
}
