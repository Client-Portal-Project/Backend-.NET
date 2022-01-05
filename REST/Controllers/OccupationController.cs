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
    public class OccupationController : ControllerBase
    {
        private readonly IOccupationRepo _orepo;
        private readonly ILogger<OccupationController> _logger;

        public OccupationController(IGenericRepo<Occupation> gen_orepo, IOccupationRepo crepo, ILogger<OccupationController> logger) 
        {
            _orepo = crepo;
            _logger = logger;
        }

        // GET: api/Occupations
        /// <summary>
        /// Get's all Occupations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Occupation>> Get()
        {
            var Occupations = await _orepo.GetAll();
            return Ok(Occupations);
        }

        // GET api/post/5
        /// <summary>
        /// GET one Occupations by Occupation ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Occupation = await _orepo.GetById(id);
            if (Occupation == null) return NotFound();
            return Ok(Occupation);
        }

        // POST api/Occupation
        /// <summary>
        /// Create a Occupation
        /// </summary>
        /// <param name="Occupation"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Occupation entity)
        {
            _orepo.Add(entity);
            this.SaveThread();
            return Created("api/AddOccupation", entity);
        }

    // PUT api/Occupation/5
    /// <summary>
    /// Update Occupation
    /// </summary>
    /// <param name="id"></param>
    /// <param name="Occupation"></param>
    /// <returns></returns>
    [HttpPut]
        public IActionResult Update(Occupation entity)
        {
            _orepo.Update(entity);
            //this is async
            this.SaveThread();
            //there should always be an existing entity
            //if (OccupationToUpdate == null) return BadRequest();
            return Ok(entity);
        }

        // <summary>
        /// Delete Occupation 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Occupation entity)
        {
            _orepo.Delete(entity);
            this.SaveThread();
            // should be pulling an existing entity, should always exist
            //if(Occupation == null) return NotFound();
            return Ok();
        }

        public async void SaveThread()
        {
            await _orepo.Save();
        }
    }
}
