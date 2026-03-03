using System.Collections.Generic;
using System.Linq;
using ClientManagerApi.Data;
using ClientManagerApi.Models;

namespace ClientManagerApi.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAll()
        {
            return _context.Clients.ToList();
        }

        public async Task<Client> Add(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client?> GetClientById(int clientId)
        {
            return _context.Clients.FirstOrDefault(x => x.Id == clientId);
        }
    }
}
