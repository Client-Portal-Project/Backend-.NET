using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using REST.DataLayer.Interfaces;
using REST.DataLayer;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Revisit, ensure the Controller applies to our entity model, refactor if needed
namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepo _crepo;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IGenericRepo<Client> gen_crepo, IClientRepo crepo, ILogger<ClientController> logger) 
        {
            _crepo = crepo;
            _logger = logger;
        }

        // GET: api/clients
        /// <summary>
        /// Get's all clients
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Client>> Get()
        {
            var clients = await _crepo.GetAll();
            return Ok(clients);
        }

        // GET api/post/5
        /// <summary>
        /// GET one clients by client ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Client client = await _crepo.GetById(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        // POST api/client
        /// <summary>
        /// Create a Client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Client client)
        {

            return Created("api/AddClient", await _crepo.Add(client));
        }

    // PUT api/client/5
    /// <summary>
    /// Update Client
    /// </summary>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <returns></returns>
    [HttpPut]
        public IActionResult Update(Client client)
        {
            Client clientToUpdate = _crepo.Update(client);

            //this is async
            _crepo.Save();

            //there should always be an existing entity
            //if (clientToUpdate == null) return BadRequest();
            return Ok(clientToUpdate);
        }

        // <summary>
        /// Delete Client 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _crepo.GetById(id);
            _crepo.Delete(entity);
            _crepo.Save();

            // should be pulling an existing entity, should always exist
            //if(client == null) return NotFound();
            return Ok();
        }
    }
}
