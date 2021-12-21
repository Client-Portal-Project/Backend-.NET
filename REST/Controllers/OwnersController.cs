using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REST.BusinessLayer;
using REST.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase{
        private readonly IOwnerRepo _ownerRepo;
        public OwnersController(IOwnerRepo ownerRepo)
        {
            _ownerRepo = ownerRepo;
        }

        // post Owner
        [HttpPost]
        public async Task<IActionResult> PostOwnerAsync(Owner owner)
        {
            Console.WriteLine(owner);
            if (owner == null)
            {
                throw new System.ArgumentNullException(nameof(owner));
            }
            Owner newOwner = await _ownerRepo.CreateOwnerAsync(owner);
            return Created("api/AddOwner", await _ownerRepo.CreateOwnerAsync(owner));
        }

        // delete Owner
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwnerByIdAsync(int id)
        {
            string result = await _ownerRepo.DeleteOwnerByIdAsync(id);
            if (result == "Owner deleted")
            {
                return Ok(result);
            }
            return NotFound($"No user with id {id} found");
        }

        // get Owner{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwnerByIdAsync(int id){
            Owner owner = await _ownerRepo.GetOwnerByIdAsync(id);
            if(owner == null)
            {
                return NotFound();
            }else{
                return Ok(owner);
            }
        }

        // get Owners
        [HttpGet]
        public async Task<IActionResult> GetOwnersAsync()
        {
            List<Owner> owners = await _ownerRepo.GetOwnersAsync();
            if (owners == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(owners);
            }

        }

        // put Owner
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwnerAsync(int id, [FromBody] Owner owner)
        {
            if (owner == null)
            {
                throw new System.ArgumentNullException(nameof(owner));
            }
            Owner updatedOwner = await _ownerRepo.UpdateOwnerAsync(owner);
            if (updatedOwner == null)
            {
                return NotFound();
            }
            return Ok(updatedOwner);
        }
        

    }
}