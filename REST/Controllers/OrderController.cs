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
    public class OrderController : ControllerBase
    {
        private readonly IOrderBL _orderBL;
        public OrderController(IOrderBL orderBL)
        {
            _orderBL = orderBL;
        }

        ///<summary>
        ///Returns all orders as a List
        ///</summary>
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _orderBL.GetOrders());
        }

        ///<summary>
        ///Returns a single order based on an ID
        ///</summary>
        ///<param name="id"></param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdersById(int id)
        {
            Order order = await _orderBL.GetOrdersById(id);
            if(order == null) return NotFound();
            return Ok(order);
        }

        ///<summary>
        ///Returns a orders from a specific based on a client ID
        ///</summary>
        ///<param name="id"></param>
        [HttpGet("GetOrdersByClientId/{ClientId}")]
        public async Task<IActionResult> GetOrdersByClientId(int ClientId)
        {
            List<Order> order = await _orderBL.GetOrdersByClientId(ClientId);
            if (order.Count() == 0) return NotFound();
            return Ok(order);
        }

        ///<summary>
        ///Creates a new order based on the order object given
        ///</summary>
        ///<param name="clients"></param>
        ///<param name="orderDetails"></param>
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            return Created("api", await _orderBL.PlaceOrder(order));
        }

        ///<summary>
        ///update a order based on the order object given
        ///</summary>
        ///<param name="order"></param>
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            Order orderToUpdate = await _orderBL.UpdateOrders(order);
            if (orderToUpdate == null) return BadRequest();
            return Ok(orderToUpdate);
        }

        ///<summary>
        ///Delete a order based on a given ID
        ///</summary>
        ///<param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            Order order = await _orderBL.DeleteOrderById(id);
            if(order == null) return NotFound();
            return Ok(order);
        }

    }
}
