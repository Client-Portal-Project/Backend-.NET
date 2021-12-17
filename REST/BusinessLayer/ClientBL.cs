using REST.DataLayer;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.BusinessLayer
{
    public class ClientBL:IClientBL
    {
        private readonly IClientRepo _clientRepo;
        public ClientBL(IClientRepo clientrepo) {
            _clientRepo = clientrepo;
        }

        public async Task<Client> AddClient(Client client)
        {
            return await _clientRepo.AddClient(client);
        }

        public async Task<List<Client>> GetClients()
        {
            return await _clientRepo.GetClients();
        }

        public async Task<Client> GetClientsById(int Id)
        {
            return await _clientRepo.GetClientsById(Id);
            
        }

        public async Task<Client> UpdateClients(Client client)
        {
            return await _clientRepo.UpdateClients(client);
        }

        public async Task<Client> DeleteClientById(int ClientId)
        {
            return await _clientRepo.DeleteClientById(ClientId);
        }
    }
}
