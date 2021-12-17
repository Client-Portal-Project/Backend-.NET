using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.BusinessLayer
{
    public interface IClientBL
    {
        /// <summary>
        /// add new client in the Database
        /// </summary>
        /// <param name="client"></param>
        /// <returns>Client object</returns>
        Task<Client> AddClient(Client client);

        /// <summary>
        /// get all the clients in the database
        /// </summary>
        /// <returns>List of clients</returns>
        Task<List<Client>> GetClients();

        /// <summary>
        /// get a client by client id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Client object</returns>ram>
        /// <returns></returns>
        Task<Client> GetClientsById(int Id);

        /// <summary>
        /// updates a client's info in the database
        /// </summary>
        /// <param name="client"></param>
        /// <returns>Clients object or null if no object found</returns>
        Task<Client> UpdateClients(Client client);

        /// <summary>
        /// remove a client from the data base by client id
        /// </summary>
        /// <param name="ClientId"></param>
        /// <returns>Client object</returns>
        Task<Client> DeleteClientById(int ClientId);

    }

}
