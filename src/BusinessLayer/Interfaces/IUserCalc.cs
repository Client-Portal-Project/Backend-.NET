using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IUserCalc
    {
        Task<User> GetById(int id);
        Task<User> GetByEmail(string email);
        Task<IEnumerable<User>> GetAll();
        Task<User> Add(User entity);
        Task<User> Update(User entity);
        Task<User> Delete(User entity);
        Task<User> Delete(int id);
        Task<bool> Exists(int id);
        Task<bool> Exists(string email);
    }
}