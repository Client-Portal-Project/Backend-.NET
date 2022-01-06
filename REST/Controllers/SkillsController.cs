using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using REST.BusinessLayer;
using REST.DataLayer;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {

        private readonly ISkillRepo _srepo;
        private readonly ILogger<ClientController> _logger;

        public SkillsController(ISkillRepo srepo, ILogger<ClientController> logger)
        {
            _srepo = srepo;
            _logger = logger;
        }

        // GET: api/clients
        /// <summary>
        /// Get's all Skills
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Skill>> Get()
        {
            var Skills = await _srepo.GetAllSkills();
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
            var Skill = await _srepo.GetSkillsById(id);
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
        public async Task<IActionResult> Post(Skill Skill)
        {

            return Created("api/AddSkill", await _srepo.AddSkill(Skill));
        }

        // PUT api/client/5
        /// <summary>
        /// Update Skill
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Skill"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Skill Skill)
        {
            Skill updatedSkill = await _srepo.UpdateSkills(Skill);
            if (updatedSkill == null) return BadRequest();
            return Ok(updatedSkill);
        }

        // <summary>
        /// Delete Skill 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Skill Skill = await _srepo.DeleteSkillById(id);
            if (Skill == null) return NotFound();
            return Ok();
        }
    }
}
