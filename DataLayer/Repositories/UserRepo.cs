using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace DataLayer
{
    public class UserRepo : GenericRepo<User>, IUser
    {
        public UserRepo(BatchesDBContext context) : base(context)
        {
        }
    }
}
