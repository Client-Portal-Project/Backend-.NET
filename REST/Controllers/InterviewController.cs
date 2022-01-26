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
    public class InterviewController : ControllerBase
    {
        private readonly IInterview _nrepo;

        public InterviewController(IInterview nrepo)
        {
            _nrepo = nrepo;
        }

        // GET: api/clients
        /// <summary>
        /// Get's all Interviews
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Interview>> Get()
        {
            var Interviews = await _nrepo.GetAll();
            return Ok(Interviews);
        }

        // GET api/post/5
        /// <summary>
        /// GET one Interviews by client ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Interview Interview = await _nrepo.GetById(id);
            if (Interview == null) return NotFound();
            return Ok(Interview);
        }

        // POST api/client
        /// <summary>
        /// Create a Interview
        /// </summary>
        /// <param name="Interview"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Interview entity)
        {
            _nrepo.Add(entity);
            _nrepo.Save();
            return Created("api/AddInterview", entity);
        }

        // PUT api/client/5
        /// <summary>
        /// Update Interview
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Interview"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Interview Interview)
        {
            _nrepo.Update(Interview);
            //async method
            _nrepo.Save();
            return Ok(Interview);
        }

        // <summary>
        /// Delete Interview 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Interview entity)
        {
            _nrepo.Delete(entity);
            _nrepo.Save();
            return Ok();
        }
    }
}
