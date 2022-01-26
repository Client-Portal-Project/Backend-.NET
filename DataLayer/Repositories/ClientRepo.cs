﻿using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace DataLayer
{
    public class ClientRepo : GenericRepo<Client>, IClient
    {
        private readonly BatchesDBContext _context;
        public ClientRepo(BatchesDBContext context) : base(context)
        {
            _context = context;
        }

        public Client GetByIdWithNavProps(int id)
        {
            var client = _context.Clients
                .Include(c => c.ClientUsers)
                .Include(c => c.Needs)
                .Single(c => c.ClientId.Equals(id));
            return client;
        }
    }
}
