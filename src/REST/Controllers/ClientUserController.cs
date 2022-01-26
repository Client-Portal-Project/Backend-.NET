using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientUserController : ControllerBase
    {
        private readonly IClientUser _nrepo;

        public ClientUserController(IClientUser nrepo)
        {
            _nrepo = nrepo;
        }

        // GET: api/clients
        /// <summary>
        /// Get's all ClientUsers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ClientUser>> Get()
        {
            var ClientUsers = await _nrepo.GetAll();
            return Ok(ClientUsers);
        }

        // GET api/post/5
        /// <summary>
        /// GET one ClientUsers by client ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ClientUser ClientUser = await _nrepo.GetById(id);
            if (ClientUser == null) return NotFound();
            return Ok(ClientUser);
        }

        // POST api/client
        /// <summary>
        /// Create a ClientUser
        /// </summary>
        /// <param name="ClientUser"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ClientUser entity)
        {
            _nrepo.Add(entity);
            _nrepo.Save();
            return Created("api/AddClientUser", entity);
        }

        // PUT api/client/5
        /// <summary>
        /// Update ClientUser
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ClientUser"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(ClientUser ClientUser)
        {
            _nrepo.Update(ClientUser);
            //async method
            _nrepo.Save();
            return Ok(ClientUser);
        }

        // <summary>
        /// Delete ClientUser 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(ClientUser entity)
        {
            _nrepo.Delete(entity);
            _nrepo.Save();
            return Ok();
        }
    }
}
