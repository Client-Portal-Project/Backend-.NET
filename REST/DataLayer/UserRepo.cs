using Microsoft.EntityFrameworkCore;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.DataLayer
{
    public class UserRepo: IUserRepo
    {
        private readonly BatchesDBContext _context;
        public UserRepo(BatchesDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get all the users in the database
        /// </summary>
        /// <returns>List of users</returns>
        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.AsNoTracking().Select(cl => cl).ToListAsync();
        }


        /// <summary>
        /// add new user in the Database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>user object</returns>
        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        /// <summary>
        /// updates a user's info in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>users object or null if no object found</returns>
        public async Task<User> UpdateUsers(User user)
        {
            if (_context.Users.Where(c => c.UserId == user.UserId).Select(x => x).Count() == 1) // id exists
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        /// <summary>
        /// get a user by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>user object</returns>
        public async Task<User> GetUsersById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.UserId == id);
        }

        /// <summary>
        /// remove a user from the data base by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>user object</returns>
        public async Task<User> DeleteUserById(int userId)
        {
            User user = await _context.Users.FirstOrDefaultAsync(c => c.UserId == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }

            return user;
        }
    }
}
