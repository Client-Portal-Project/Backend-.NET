using Microsoft.EntityFrameworkCore;
using REST.DataLayer.Interfaces;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.DataLayer
{
    public class NeedRepo : GenericRepo<Need>, INeedRepo
    {
        private readonly BatchesDBContext _context;
        public NeedRepo(BatchesDBContext context) : base(context)
        {
            _context = context;
        }

        
    }
}
