using System.Collections.Generic;
using System.Linq;
using ClientManagerApi.Data;
using ClientManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientManagerApi.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAll(int userId)
        {
            return await _context.Clients.Where(x => x.OwnerUserId == userId).ToListAsync();
        }

        public async Task<Client> Add(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client?> GetClientById(int clientId, int userId)
        {
            return _context.Clients.FirstOrDefault(x => x.Id == clientId && x.OwnerUserId == userId);
        }
    }
}
