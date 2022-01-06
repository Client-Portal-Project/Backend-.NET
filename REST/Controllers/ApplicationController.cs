using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST.BusinessLayer;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepo _arepo;

        public ApplicationController(IApplicationRepo arepo)
        {
            _arepo = arepo;
        }

        // GET: api/applications
        /// <summary>
        /// Get's all applications
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Application>> Get()
        {
            var applications = await _arepo.GetApplications();
            return Ok(applications);
        }

        // GET api/post/5
        /// <summary>
        /// GET one applications by application ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Application application = await _arepo.GetApplicationsById(id);
            if (application == null) return NotFound();
            return Ok(application);
        }

        // POST api/application
        /// <summary>
        /// Create a application
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Application application)
        {

            return Created("api/Addapplication", await _arepo.AddAnApplication(application));
        }

        // PUT api/application/5
        /// <summary>
        /// Update application
        /// </summary>
        /// <param name="id"></param>
        /// <param name="application"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Application application)
        {
            Application applicationToUpdate = await _arepo.UpdateApplications(application);
            if (applicationToUpdate == null) return BadRequest();
            return Ok(applicationToUpdate);
        }

        // <summary>
        /// Delete application 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Application application = await _arepo.DeleteAnApplicationById(id);
            if (application == null) return NotFound();
            return Ok();
        }

    }
}
