using Microsoft.EntityFrameworkCore;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.DataLayer
{
    public class OrderRepo : IOrderRepo
    {
        private readonly BatchesDBContext _context;
        public OrderRepo(BatchesDBContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders.AsNoTracking().Select(order => order).ToListAsync();
        }

        public async Task<Order> PlaceOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> GetOrdersById(int Id)
        {
            return await _context.Orders.AsNoTracking().SingleOrDefaultAsync(o => o.Id == Id);
        }

        public async Task<Order> UpdateOrders(Order order)
        {
            if (_context.Orders.Where(o => o.Id == order.Id).Select(x => x).Count() == 1) // id exists
            {
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
                return order;
            }
            return null;
        }

        public async Task<Order> DeleteOrderById(int OrderId)
        {
            Order order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == OrderId);
            OrderLine orderLines = _context.OrderLines.FirstOrDefault(o => o.Id == OrderId);
            if (order != null)
            {
                if (orderLines != null)
                    _context.OrderLines.Remove(orderLines);
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }

            return order;
        }

        public async Task<List<Order>> GetOrdersByClientId(int ClientId)
        {
            return await _context.Orders.AsNoTracking().Select(order => order).Where(o => o.ClientId == ClientId).ToListAsync();
        }

    }
}
