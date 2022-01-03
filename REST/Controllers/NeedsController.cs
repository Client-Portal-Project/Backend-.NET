using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using REST.DataLayer.Interfaces;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeedsController : ControllerBase
    {
        private readonly INeedRepo _nrepo;
        private readonly ILogger<ClientController> _logger;

        public NeedsController(IGenericRepo<Need> gen_nrepo, INeedRepo nrepo, ILogger<ClientController> logger)
        {
            _nrepo = nrepo;
            _logger = logger;
        }

        // GET: api/clients
        /// <summary>
        /// Get's all needs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Need>> Get()
        {
            var needs = await _nrepo.GetAll();
            return Ok(needs);
        }

        // GET api/post/5
        /// <summary>
        /// GET one needs by client ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Need need = await _nrepo.GetById(id);
            if (need == null) return NotFound();
            return Ok(need);
        }

        // POST api/client
        /// <summary>
        /// Create a Need
        /// </summary>
        /// <param name="need"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Need need)
        {

            return Created("api/AddNeed", await _nrepo.Add(need));
        }

        // PUT api/client/5
        /// <summary>
        /// Update Need
        /// </summary>
        /// <param name="id"></param>
        /// <param name="need"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Need need)
        {
            Need updatedneed = _nrepo.Update(need);
            //async method
            _nrepo.Save();
            //should have an existing entity
            //if (updatedneed == null) return BadRequest();
            return Ok(updatedneed);
        }

        // <summary>
        /// Delete need 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Need entity)
        {
            _nrepo.Delete(entity);
            //async
            _nrepo.Save();
            //existing entity we're deleting
            //if (need == null) return NotFound();
            return Ok();
        }
    }
}
