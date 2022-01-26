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
    public class UserController : ControllerBase
    {
        private readonly IUser _nrepo;

        public UserController(IUser nrepo)
        {
            _nrepo = nrepo;
        }

        // GET: api/clients
        /// <summary>
        /// Get's all Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<User>> Get()
        {
            var Users = await _nrepo.GetAll();
            return Ok(Users);
        }

        // GET api/post/5
        /// <summary>
        /// GET one Users by client ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            User User = await _nrepo.GetById(id);
            if (User == null) return NotFound();
            return Ok(User);
        }

        // POST api/client
        /// <summary>
        /// Create a User
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(User entity)
        {
            _nrepo.Add(entity);
            _nrepo.Save();
            return Created("api/AddUser", entity);
        }

        // PUT api/client/5
        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(User User)
        {
            _nrepo.Update(User);
            //async method
            _nrepo.Save();
            return Ok(User);
        }

        // <summary>
        /// Delete User 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(User entity)
        {
            _nrepo.Delete(entity);
            _nrepo.Save();
            return Ok();
        }
    }
}
