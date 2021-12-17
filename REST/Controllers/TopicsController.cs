using Microsoft.AspNetCore.Mvc;
using REST.BusinessLayer;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicBL _topicBl;
        public TopicsController(ITopicBL topicBl)
        {
            _topicBl = topicBl;

        }

        // GET: api/<TopicsController>
        [HttpGet]
        public async Task<ActionResult> GetTopics()
        {
            return Ok(await _topicBl.GetTopics());
           
        }

        // GET api/<TopicsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTopicsById(int id)
        {
            var topic = await _topicBl.GetTopicsById(id);
            if (topic != null) return Ok(topic);
            else return NotFound();
        }

        // POST api/<TopicsController>
        [HttpPost]
        public async Task<ActionResult> Post(Topic t)
        {
            return Created("api/AddTopics", await _topicBl.AddTopic(t));
        }

        // DELETE api/<TopicsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Topic topic = await _topicBl.DeleteTopicById(id);
            if (topic != null) return Ok(topic);
            else return NotFound();
        }

        /// <summary>
        /// Assoicate a topic and Occupation
        /// </summary>
        /// <param name="topicId"></param>
        /// <param name="OccupationId"></param>
        /// <returns></returns>
        [HttpPost("{topicId}/{OccupationId}")]
        public async Task<ActionResult> AddTopicToOccupation(int topicId, int OccupationId)
        {
            var join = await _topicBl.AddTopicToOccupation(topicId, OccupationId);
            if (join.TopicsId != 0 && join.OccupationsId != 0) return Created($"api/Topics/{topicId}/{OccupationId}", join);
            else return BadRequest();
        }

    }
}
