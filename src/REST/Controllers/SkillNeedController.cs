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
    public class SkillNeedController : ControllerBase
    {
        private readonly ISkillNeed _nrepo;

        public SkillNeedController(ISkillNeed nrepo)
        {
            _nrepo = nrepo;
        }

        // GET: api/clients
        /// <summary>
        /// Get's all SkillNeeds
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<SkillNeed>> Get()
        {
            var SkillNeeds = await _nrepo.GetAll();
            return Ok(SkillNeeds);
        }

        // GET api/post/5
        /// <summary>
        /// GET one SkillNeeds by client ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            SkillNeed SkillNeed = await _nrepo.GetById(id);
            if (SkillNeed == null) return NotFound();
            return Ok(SkillNeed);
        }

        // POST api/client
        /// <summary>
        /// Create a SkillNeed
        /// </summary>
        /// <param name="SkillNeed"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(SkillNeed entity)
        {
            _nrepo.Add(entity);
            _nrepo.Save();
            return Created("api/AddSkillNeed", entity);
        }

        // PUT api/client/5
        /// <summary>
        /// Update SkillNeed
        /// </summary>
        /// <param name="id"></param>
        /// <param name="SkillNeed"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(SkillNeed SkillNeed)
        {
            _nrepo.Update(SkillNeed);
            //async method
            _nrepo.Save();
            return Ok(SkillNeed);
        }

        // <summary>
        /// Delete SkillNeed 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(SkillNeed entity)
        {
            _nrepo.Delete(entity);
            _nrepo.Save();
            return Ok();
        }
    }
}
