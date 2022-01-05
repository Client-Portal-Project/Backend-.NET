using Microsoft.EntityFrameworkCore;
using REST.DataLayer.Interfaces;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.DataLayer
{
    public class OrderRepo : GenericRepo<Order>, IOrderRepo
    {
        private readonly BatchesDBContext _context;
        public OrderRepo(BatchesDBContext context) : base(context)
        {
            _context = context;
        }

        
    }
}
