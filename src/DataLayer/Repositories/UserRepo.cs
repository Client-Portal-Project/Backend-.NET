using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace DataLayer
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(BatchesDBContext context) : base(context){}

        public override async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(s => s.UserId == id);
        }
        public override async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(s => s.Email == email);
        }

        public override async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public override async Task<User> Add(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task<User> Update(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public override async Task<User> Delete(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public override async Task<bool> Exists(int id)
        {
            return await _context.Users.AnyAsync(s => s.UserId == id);
        }
        public override async Task<bool> Exists(string email)
        {
            return await _context.Users.AnyAsync(s => s.Email == email);
        }

    }
}
