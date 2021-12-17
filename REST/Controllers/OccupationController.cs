using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using REST.BusinessLayer;
using REST.DataLayer;
using REST.Models;

namespace REST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OccupationController : ControllerBase
    {
        private readonly IOccupationBL _OccupationBL;

        public OccupationController(IOccupationBL OccupationBL)
        {
            _OccupationBL = OccupationBL;

        }

        ///<summary>
        ///Returns all Occupations as a List
        ///</summary>
        [HttpGet]
        public async Task<IActionResult> GetOccupations()
        {
            return Ok(await _OccupationBL.GetOccupations());
        }

        ///<summary>
        ///Returns a single Occupation based on an ID
        ///</summary>
        ///<param name="id"></param>
        [HttpGet("FindOccupationById/{OccupationId}")]
        public async Task<IActionResult> FindOccupationById(int OccupationId)
        {
            Occupation Occupation = await _OccupationBL.FindOccupationById(OccupationId);
            if(Occupation == null) return NotFound();
            return Ok(Occupation);

        }

        /// <summary>
        /// Returns a single Occupation by its name
        /// </summary>
        /// <param name="OccupationName"></param>
        /// <returns></returns>
        [HttpGet("FindOccupationByName/{OccupationName}")]
        public async Task<IActionResult> FindOccupationByName(string OccupationName)
        {
            Occupation Occupation = await _OccupationBL.FindOccupationByName(OccupationName);
            if (Occupation == null) return NotFound();
            return Ok(Occupation);


        }

        /// <summary>
        /// Returns Occupations which cover a certain topic
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        [HttpGet("FindOccupationsByTopicId/{TopicId}")]
        public async Task<IActionResult> FindOccupationsByTopicId(int TopicId)
        {
            var Occupations = await _OccupationBL.GetOccupationsByTag(TopicId);
            if (Occupations.Count() == 0) return NotFound();
            return Ok(Occupations);
        }

        ///<summary>
        ///Creates a new Occupation based on the Occupation object given
        ///</summary>
        ///<param name="Occupation"></param>
        [HttpPost]
        public async Task<IActionResult> CreateOccupation(Occupation Occupation)
        {

            return Created("api", await _OccupationBL.AddOccupation(Occupation));

        }

        ///<summary>
        ///update a Occupation based on the Occupation object given
        ///</summary>
        ///<param name="Occupation"></param>
        [HttpPut]
        public async Task<IActionResult> UpdateOccupation(Occupation Occupation)
        {
            Occupation OccupationToUpdate = await _OccupationBL.UpdateOccupations(Occupation);
            if (OccupationToUpdate == null) return BadRequest();
            return Ok(OccupationToUpdate);
        }

        ///<summary>
        ///Delete a Occupation based on a given ID
        ///</summary>
        ///<param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOccupation(int id)
        {
            Occupation Occupation = await _OccupationBL.DeleteOccupationById(id);
            if(Occupation == null) return NotFound();
            return Ok(Occupation);

        }

    }
}
