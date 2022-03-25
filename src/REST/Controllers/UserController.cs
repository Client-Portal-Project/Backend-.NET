
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCalc _calc;

        public UserController(IUserCalc calc){
            _calc = calc;
        }

        [HttpGet]
        public async Task<ActionResult<User>> Get(){
            var Users = await _calc.GetAll();
            if (Users == null) return NotFound();
            return Ok(Users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id){
            var User = await _calc.GetById(id);
            if (User == null) return NotFound();
            return Ok(User);
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email){
            var User = await _calc.GetByEmail(email);
            if (User == null) return NotFound();
            return Ok(User);
        }
        [HttpPost]
        public IActionResult Post(User entity){
            return _calc.Add(entity);
        }
        [HttpPut]
        public IActionResult Update(User User){
            return _calc.Update(User);
        }
        [HttpDelete]
        public IActionResult Delete(User User){
            return _calc.Delete(User);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            return _calc.Delete(id);
        }
        [HttpGet("exists/{id}")]
        public async Task<IActionResult> Exists(int id){
            return Ok(await _calc.Exists(id));
        }
        [HttpGet("exists/{email}")]
        public async Task<IActionResult> Exists(string email){
            return Ok(await _calc.Exists(email));
        }
    }
}
