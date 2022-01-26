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
    public class ApplicationController : ControllerBase
    {
        private readonly IApplication _nrepo;

        public ApplicationController(IApplication nrepo)
        {
            _nrepo = nrepo;
        }

        // GET: api/clients
        /// <summary>
        /// Get's all Applications
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Application>> Get()
        {
            var Applications = await _nrepo.GetAll();
            return Ok(Applications);
        }

        // GET api/post/5
        /// <summary>
        /// GET one Applications by client ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Application Application = await _nrepo.GetById(id);
            if (Application == null) return NotFound();
            return Ok(Application);
        }

        // POST api/client
        /// <summary>
        /// Create a Application
        /// </summary>
        /// <param name="Application"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Application entity)
        {
            _nrepo.Add(entity);
            _nrepo.Save();
            return Created("api/AddApplication", entity);
        }

        // PUT api/client/5
        /// <summary>
        /// Update Application
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Application"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Application Application)
        {
            _nrepo.Update(Application);
            //async method
            _nrepo.Save();
            return Ok(Application);
        }

        // <summary>
        /// Delete Application 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Application entity)
        {
            _nrepo.Delete(entity);
            _nrepo.Save();
            return Ok();
        }
    }
}
