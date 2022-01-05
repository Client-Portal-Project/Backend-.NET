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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _orepo;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IGenericRepo<Order> gen_orepo, IOrderRepo crepo, ILogger<OrderController> logger) 
        {
            _orepo = crepo;
            _logger = logger;
        }

        // GET: api/Orders
        /// <summary>
        /// Get's all Orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Order>> Get()
        {
            var Orders = await _orepo.GetAll();
            return Ok(Orders);
        }

        // GET api/post/5
        /// <summary>
        /// GET one Orders by Order ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Order = await _orepo.GetById(id);
            if (Order == null) return NotFound();
            return Ok(Order);
        }

        // POST api/Order
        /// <summary>
        /// Create a Order
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Order entity)
        {
            _orepo.Add(entity);
            this.SaveThread();
            return Created("api/AddOrder", entity);
        }

    // PUT api/Order/5
    /// <summary>
    /// Update Order
    /// </summary>
    /// <param name="id"></param>
    /// <param name="Order"></param>
    /// <returns></returns>
    [HttpPut]
        public IActionResult Update(Order entity)
        {
            _orepo.Update(entity);
            //this is async
            this.SaveThread();
            //there should always be an existing entity
            //if (OrderToUpdate == null) return BadRequest();
            return Ok(entity);
        }

        // <summary>
        /// Delete Order 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Order entity)
        {
            _orepo.Delete(entity);
            this.SaveThread();
            // should be pulling an existing entity, should always exist
            //if(Order == null) return NotFound();
            return Ok();
        }

        public async void SaveThread()
        {
            await _orepo.Save();
        }
    }
}
