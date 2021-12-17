using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.BusinessLayer
{
    public interface IOrderBL
    {
        /// <summary>
        /// place an order for a given customer
        /// </summary>
        /// <param name="order"></param>
        /// <returns> Orders object</returns>
        Task<Order> PlaceOrder(Order order);

        /// <summary>
        /// get a list of all orders in the database
        /// </summary>
        /// <returns>list of orders</returns>
        Task<List<Order>> GetOrders();

        /// <summary>
        /// get an order from the database by order id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Orders object</returns>
        Task<Order> GetOrdersById(int Id);

        /// <summary>
        /// updates an order in the database
        /// </summary>
        /// <param name="order"></param>
        /// <returns>updates an order in database or null if no such object exists</returns>
        Task<Order> UpdateOrders(Order order);

        /// <summary>
        /// deletes an order from the database by order id
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns>Orders object</returns>
        Task<Order> DeleteOrderById(int OrderId);

        /// <summary>
        /// get all orders place by a specific client by client id
        /// </summary>
        /// <param name="ClientId"></param>
        /// <returns>list of orders</returns>
        Task<List<Order>> GetOrdersByClientId(int ClientId);
    }
}
