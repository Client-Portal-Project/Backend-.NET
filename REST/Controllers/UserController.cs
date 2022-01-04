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
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;

        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        // GET: api/clients
        /// <summary>
        /// Get's all clients
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<User>> Get()
        {
            var users = await _userBL.GetUsers();
            return Ok(users);
        }

        // GET api/post/5
        /// <summary>
        /// GET one clients by client ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            User user = await _userBL.GetUsersById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/client
        /// <summary>
        /// Create a Client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {

            return Created("api/AddClient", await _userBL.AddUser(user));
        }

        // PUT api/client/5
        /// <summary>
        /// Update Client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            User userToUpdate = await _userBL.UpdateUsers(user);
            if (userToUpdate == null) return BadRequest();
            return Ok(userToUpdate);
        }

        // <summary>
        /// Delete Client 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            User user = await _userBL.DeleteUserById(id);
            if (user == null) return NotFound();
            return Ok();
        }
    }
}
