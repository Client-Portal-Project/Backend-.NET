using Microsoft.AspNetCore.Mvc;
using REST.BusinessLayer;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Revisit, ensure the Controller applies to our entity model, refactor if needed
namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantBL _applicantBL;

        public ApplicantController(IApplicantBL applicantBL) 
        {
            _applicantBL = applicantBL; 
        }

        // GET: api/<ApplicantController>
        [HttpGet]
        public async Task<IActionResult> GetApplicants()
        {
            return Ok(await _applicantBL.GetApplicants());
        }

        // GET api/<ApplicantController>/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicant(int id)
        {
            Applicant applicant = await _applicantBL.GetApplicantById(id);
            if (applicant == null) return NotFound();
            return Ok(applicant);
        }

        // POST api/<ApplicantController>
        [HttpPost]
        public async Task<IActionResult> Post(Applicant applicant)
        {
            return Created("api/AddApplicant", await _applicantBL.AddApplicant(applicant));
        }

        // PUT api/<ApplicantController>/id
        [HttpPut]
        public async Task<IActionResult> Update(Applicant applicant)
        {
            Applicant applicantToUpdate = await _applicantBL.UpdateApplicant(applicant);
            if (applicantToUpdate == null) return BadRequest();
            return Ok(applicantToUpdate);
        }

        // DELETE api/<ApplicantController>/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Applicant applicant = await _applicantBL.DeleteApplicantById(id);
            if(applicant == null) return NotFound();
            return Ok();
        }

        [HttpPost("occupation")]
        public async Task<IActionResult> PostApplicantOccupation(ApplicantOccupation applicantOccupation)
        {
            return Created("api/AddApplicantOccupation", await _applicantBL.AddApplicantOccupation(applicantOccupation));
        }

        [HttpGet("occupation")]
        public async Task<IActionResult> GetApplicantOccupations()
        {
            return Ok(await _applicantBL.GetApplicantOccupations());
        }

        [HttpGet("occupation/{{id}}")]
        public async Task<IActionResult> GetApplicantOccupationById(int id)
        {
            ApplicantOccupation applicantOccupation = await _applicantBL.GetApplicantOccupationById(id);
            if (applicantOccupation == null) return NotFound();
            return Ok(applicantOccupation);
        }

        [HttpGet("occupation/applicant/{{id}}")]
        public async Task<IActionResult> GetApplicantOccupationsByApplicantId(int applicantId)
        {
            List<ApplicantOccupation> applicantOccupations = await _applicantBL.GetApplicantOccupationByApplicantId(applicantId);
            if (applicantOccupations == null) return NotFound();
            return Ok(applicantOccupations);
        }

        [HttpPut("occupation")]
        public async Task<IActionResult> UpdateApplicantOccupation(ApplicantOccupation applicantOccupation)
        {
            ApplicantOccupation applicantOccupationToUpdate = await _applicantBL.UpdateApplicantOccupation(applicantOccupation);
            if (applicantOccupationToUpdate == null) return BadRequest();
            return Ok(applicantOccupationToUpdate);
        }

        [HttpDelete("occupation/{{id}}")]
        public async Task<IActionResult> DeleteApplicantOccupation(int id)
        {
            ApplicantOccupation applicantOccupation = await _applicantBL.DeleteApplicantOccupation(id);
            if(applicantOccupation == null) return NotFound();
            return Ok();
        }

        [HttpPost("skill")]
        public async Task<IActionResult> PostApplicantSkill(ApplicantSkill applicantSkill)
        {
            return Created("api/AddApplicantSkill", await _applicantBL.AddApplicantSkill(applicantSkill));
        }

        [HttpGet("skill/applicant/{{applicantId}}")]
        public async Task<IActionResult> GetApplicantSkillsByApplicantId(int applicantId)
        {
            List<ApplicantSkill> applicantSkills = await _applicantBL.GetApplicantSkillsByApplicantId(applicantId);
            if (applicantSkills == null) return NotFound();
            return Ok(applicantSkills);
        }

        [HttpGet("skill/skill/{{skillId}}")]
        public async Task<IActionResult> GetApplicantSkillsBySkillId(int skillId)
        {
            List<ApplicantSkill> applicantSkills = await _applicantBL.GetApplicantSkillsBySkillId(skillId);
            if (applicantSkills == null) return NotFound();
            return Ok(applicantSkills);
        }

        [HttpDelete("skill/{id}")]
        public async Task<IActionResult> DeleteApplicantSkill(int id)
        {
            ApplicantSkill applicantSkill = await _applicantBL.DeleteApplicantSkill(id);
            if(applicantSkill == null) return NotFound();
            return Ok();
        }
    }
}
