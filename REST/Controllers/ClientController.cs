using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Revisit, ensure the Controller applies to our entity model, refactor if needed
namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClient _crepo;

        public ClientController(IClient crepo)
        {
            _crepo = crepo;
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
            var client = await _crepo.GetById(id);
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
        public IActionResult Post(Client entity)
        {
            _crepo.Add(entity);
            _crepo.Save();
            return Created("api/AddClient", entity);
        }

        // PUT api/client/5
        /// <summary>
        /// Update Client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Client entity)
        {
            _crepo.Update(entity);
            _crepo.Save();
            return Ok(entity);
        }

        // <summary>
        /// Delete Client 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Client entity)
        {
            _crepo.Delete(entity);
            _crepo.Save();
            return Ok();
        }
    }
}
