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
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicant _nrepo;

        public ApplicantController(IApplicant nrepo)
        {
            _nrepo = nrepo;
        }

        // GET: api/clients
        /// <summary>
        /// Get's all Applicants
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Applicant>> Get()
        {
            var Applicants = await _nrepo.GetAll();
            return Ok(Applicants);
        }

        // GET api/post/5
        /// <summary>
        /// GET one Applicants by client ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Applicant Applicant = await _nrepo.GetById(id);
            if (Applicant == null) return NotFound();
            return Ok(Applicant);
        }

        // POST api/client
        /// <summary>
        /// Create a Applicant
        /// </summary>
        /// <param name="Applicant"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Applicant entity)
        {
            _nrepo.Add(entity);
            _nrepo.Save();
            return Created("api/AddApplicant", entity);
        }

        // PUT api/client/5
        /// <summary>
        /// Update Applicant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Applicant"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Applicant Applicant)
        {
            _nrepo.Update(Applicant);
            //async method
            _nrepo.Save();
            return Ok(Applicant);
        }

        // <summary>
        /// Delete Applicant 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Applicant entity)
        {
            _nrepo.Delete(entity);
            _nrepo.Save();
            return Ok();
        }
    }
}
