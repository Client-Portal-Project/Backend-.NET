using Microsoft.EntityFrameworkCore;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.DataLayer
{
    public class ClientRepo : IClientRepo
    {
        private readonly BatchesDBContext _context;
        public ClientRepo(BatchesDBContext context)
        {
            _context = context;
        }
        public async Task<Client> AddClient(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return client;
        }


        public async Task<List<Client>> GetClients()
        {
            return await _context.Clients.AsNoTracking().Select(cl => cl).ToListAsync();
        }

        public Task<Client> GetClientsById(int Id)
        {
            return _context.Clients.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<Client> UpdateClients(Client client)
        {
            if (_context.Clients.Where(c => c.Id == client.Id).Select(x => x).Count() == 1) // id exists
            {
                _context.Clients.Update(client);
                await _context.SaveChangesAsync();
                return client;
            }
            return null;
        }

        public async Task<Client> DeleteClientById(int ClientId)
        {
            Client client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == ClientId);
            if(client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }

            return client;
        }
    }
}
