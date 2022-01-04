using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.BusinessLayer
{
    public interface IUserBL
    {
        /// <summary>
        /// get all the users in the database
        /// </summary>
        /// <returns>List of users</returns>
        public Task<List<User>> GetUsers();


        /// <summary>
        /// add new user in the Database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>user object</returns>
        public Task<User> AddUser(User user);

        /// <summary>
        /// updates a user's info in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>users object or null if no object found</returns>
        public Task<User> UpdateUsers(User user);

        /// <summary>
        /// get a user by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>user object</returns>
        public Task<User> GetUsersById(int id);

        /// <summary>
        /// remove a user from the data base by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>user object</returns>
        public Task<User> DeleteUserById(int userId);
    }
}
