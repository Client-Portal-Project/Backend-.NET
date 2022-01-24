using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer
{
    public class NeedRepo : GenericRepo<Need>, INeedRepo
    {
        public NeedRepo(BatchesDBContext context) : base(context)
        {
        }


    }
}
