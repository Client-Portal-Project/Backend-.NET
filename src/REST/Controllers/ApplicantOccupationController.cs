using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Revisit, ensure the Controller applies to our entity model, refactor if needed
namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantOccupationController : ControllerBase
    {
        private readonly IApplicantOccupation _orepo;

        public ApplicantOccupationController(IApplicantOccupation orepo)
        {
            _orepo = orepo;
        }

        // GET: api/ApplicantOccupations
        /// <summary>
        /// Get's all ApplicantOccupations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApplicantOccupation>> Get()
        {
            var appOccupations = await _orepo.GetAll();
            return Ok(appOccupations);
        }

        // GET api/post/5
        /// <summary>
        /// GET one ApplicantOccupations by ApplicantOccupation ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var appOccupation = await _orepo.GetById(id);
            if (appOccupation == null) return NotFound();
            return Ok(appOccupation);
        }

        // POST api/ApplicantOccupation
        /// <summary>
        /// Create a ApplicantOccupation
        /// </summary>
        /// <param name="ApplicantOccupation"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ApplicantOccupation entity)
        {
            _orepo.Add(entity);
            _orepo.Save();
            return Created("api/AddApplicantOccupation", entity);
        }

        // PUT api/ApplicantOccupation/5
        /// <summary>
        /// Update ApplicantOccupation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ApplicantOccupation"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(ApplicantOccupation entity)
        {
            _orepo.Update(entity);
            _orepo.Save();
            return Ok(entity);
        }

        // <summary>
        /// Delete ApplicantOccupation 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(ApplicantOccupation entity)
        {
            _orepo.Delete(entity);
            _orepo.Save();
            return Ok();
        }
    }
}
