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
    public class ApplicantSkillController : ControllerBase
    {
        private readonly IApplicantSkill _nrepo;

        public ApplicantSkillController(IApplicantSkill nrepo)
        {
            _nrepo = nrepo;
        }

        // GET: api/clients
        /// <summary>
        /// Get's all ApplicantSkills
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApplicantSkill>> Get()
        {
            var ApplicantSkills = await _nrepo.GetAll();
            return Ok(ApplicantSkills);
        }

        // GET api/post/5
        /// <summary>
        /// GET one ApplicantSkills by client ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ApplicantSkill ApplicantSkill = await _nrepo.GetById(id);
            if (ApplicantSkill == null) return NotFound();
            return Ok(ApplicantSkill);
        }

        // POST api/client
        /// <summary>
        /// Create a ApplicantSkill
        /// </summary>
        /// <param name="ApplicantSkill"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ApplicantSkill entity)
        {
            _nrepo.Add(entity);
            _nrepo.Save();
            return Created("api/AddApplicantSkill", entity);
        }

        // PUT api/client/5
        /// <summary>
        /// Update ApplicantSkill
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ApplicantSkill"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(ApplicantSkill ApplicantSkill)
        {
            _nrepo.Update(ApplicantSkill);
            //async method
            _nrepo.Save();
            return Ok(ApplicantSkill);
        }

        // <summary>
        /// Delete ApplicantSkill 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(ApplicantSkill entity)
        {
            _nrepo.Delete(entity);
            _nrepo.Save();
            return Ok();
        }
    }
}
