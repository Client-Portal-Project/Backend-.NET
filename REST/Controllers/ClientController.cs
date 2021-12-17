using Microsoft.AspNetCore.Mvc;
using REST.BusinessLayer;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientBL _clientBL;

        public ClientController(IClientBL clientBL) 
        {
            _clientBL = clientBL; 
        }

        // GET: api/<ClientController>
        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            return Ok(await _clientBL.GetClients());
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            Client client = await _clientBL.GetClientsById(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost()]
        public async Task<IActionResult> Post(Client client)
        {

            return Created("api/AddClient", await _clientBL.AddClient(client));
        }

        // PUT api/<ClientController>/5
        [HttpPut]
        public async Task<IActionResult> Update(Client client)
        {
            Client clientToUpdate = await _clientBL.UpdateClients(client);
            if (clientToUpdate == null) return BadRequest();
            return Ok(clientToUpdate);
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Client client = await _clientBL.DeleteClientById(id);
            if(client == null) return NotFound();
            return Ok();
        }
    }
}
