using REST.DataLayer;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.BusinessLayer
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepo _userRepo;

        public UserBL(IUserRepo userRepo)
        {
            _userRepo = userRepo;

        }

        /// <summary>
        /// get all the users in the database
        /// </summary>
        /// <returns>List of users</returns>
        public  async Task<List<User>> GetUsers()
        {
            var users = await _userRepo.GetUsers();
            return users;
        }


        /// <summary>
        /// add new user in the Database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>user object</returns>
        public async Task<User> AddUser(User user)
        {
            var newUser = await _userRepo.AddUser(user);
            return newUser;
        }

        /// <summary>
        /// updates a user's info in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>users object or null if no object found</returns>
        public async Task<User> UpdateUsers(User user)
        {
            var updatedUser = await _userRepo.UpdateUsers(user);
            return updatedUser;
        }

        /// <summary>
        /// get a user by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>user object</returns>
        public async Task<User> GetUsersById(int id)
        {
            var user = await _userRepo.GetUsersById(id);
            return user;
        }

        /// <summary>
        /// remove a user from the data base by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>user object</returns>
        public async Task<User> DeleteUserById(int userId)
        {
            var user = await _userRepo.DeleteUserById(userId);
            return user;
        }
    }
}
