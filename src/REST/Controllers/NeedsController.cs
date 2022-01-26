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
    public class NeedsController : ControllerBase
    {
        private readonly INeed _nrepo;

        public NeedsController(INeed nrepo)
        {
            _nrepo = nrepo;
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
        public IActionResult Post(Need entity)
        {
            _nrepo.Add(entity);
            _nrepo.Save();
            return Created("api/AddNeed", entity);
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
            _nrepo.Update(need);
            //async method
            _nrepo.Save();
            return Ok(need);
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
            _nrepo.Save();
            return Ok();
        }
    }
}
