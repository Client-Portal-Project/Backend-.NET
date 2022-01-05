using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using REST.DataLayer.Interfaces;
using REST.DataLayer;
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
    public class ApplicantOccupationController : ControllerBase
    {
        private readonly IApplicantOccupationRepo _orepo;
        private readonly ILogger<ApplicantOccupationController> _logger;

        public ApplicantOccupationController(IGenericRepo<ApplicantOccupation> gen_orepo, IApplicantOccupationRepo crepo, ILogger<ApplicantOccupationController> logger) 
        {
            _orepo = crepo;
            _logger = logger;
        }

        // GET: api/ApplicantOccupations
        /// <summary>
        /// Get's all ApplicantOccupations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApplicantOccupation>> Get()
        {
            var ApplicantOccupations = await _orepo.GetAll();
            return Ok(ApplicantOccupations);
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
            var ApplicantOccupation = await _orepo.GetById(id);
            if (ApplicantOccupation == null) return NotFound();
            return Ok(ApplicantOccupation);
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
            this.SaveThread();
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
            //this is async
            this.SaveThread();
            //there should always be an existing entity
            //if (ApplicantOccupationToUpdate == null) return BadRequest();
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
            this.SaveThread();
            // should be pulling an existing entity, should always exist
            //if(ApplicantOccupation == null) return NotFound();
            return Ok();
        }

        public async void SaveThread()
        {
            await _orepo.Save();
        }
    }
}
