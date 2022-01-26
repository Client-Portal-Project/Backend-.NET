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
    public class SkillController : ControllerBase
    {
        private readonly ISkill _nrepo;

        public SkillController(ISkill nrepo)
        {
            _nrepo = nrepo;
        }

        // GET: api/clients
        /// <summary>
        /// Get's all Skills
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Skill>> Get()
        {
            var Skills = await _nrepo.GetAll();
            return Ok(Skills);
        }

        // GET api/post/5
        /// <summary>
        /// GET one Skills by client ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Skill Skill = await _nrepo.GetById(id);
            if (Skill == null) return NotFound();
            return Ok(Skill);
        }

        // POST api/client
        /// <summary>
        /// Create a Skill
        /// </summary>
        /// <param name="Skill"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Skill entity)
        {
            _nrepo.Add(entity);
            _nrepo.Save();
            return Created("api/AddSkill", entity);
        }

        // PUT api/client/5
        /// <summary>
        /// Update Skill
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Skill"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Skill Skill)
        {
            _nrepo.Update(Skill);
            //async method
            _nrepo.Save();
            return Ok(Skill);
        }

        // <summary>
        /// Delete Skill 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Skill entity)
        {
            _nrepo.Delete(entity);
            _nrepo.Save();
            return Ok();
        }
    }
}
