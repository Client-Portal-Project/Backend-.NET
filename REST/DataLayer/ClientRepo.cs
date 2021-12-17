﻿﻿using Microsoft.EntityFrameworkCore;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace REST.DataLayer
{
    public class ClientRepo : IClientRepo
    {
        private readonly BatchesDBContext _context;
        public ClientRepo(BatchesDBContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get Clients
        /// </summary>
        /// <returns></returns>
        public async Task<List<Client>> GetClients()
        {
            return await _context.Clients.AsNoTracking().Select(cl => cl).ToListAsync();
        }

        /// <summary>
        /// Add Clients
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task<Client> AddClient(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return client;
        }
        /// <summary>
        /// Get specific client by their Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<Client> GetClientsById(int Id)
        {
            return _context.Clients.FirstOrDefaultAsync(c => c.ClientId == Id);
        }

        /// <summary>
        /// Update a client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task<Client> UpdateClients(Client client)
        {
            if (_context.Clients.Where(c => c.ClientId == client.ClientId).Select(x => x).Count() == 1) // id exists
            {
                _context.Clients.Update(client);
                await _context.SaveChangesAsync();
                return client;
            }
            return null;
        }

        /// <summary>
        /// Remove a Client
        /// </summary>
        /// <param name="ClientId"></param>
        /// <returns></returns>
        public async Task<Client> DeleteClientById(int clientId)
        {
            Client client = await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == clientId);
            if(client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }

            return client;
        }
    }
}
