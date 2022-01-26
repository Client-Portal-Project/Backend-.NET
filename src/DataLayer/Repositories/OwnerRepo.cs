using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OwnerRepo : GenericRepo<Owner>, IOwner
    {
        public OwnerRepo(BatchesDBContext context) : base(context)
        {
        }


    }
}
