using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace DataLayer
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<User> GetById(int id);
        Task<User> GetByEmail(string email);
        Task<IEnumerable<User>> GetAll();
        Task<User> Add(User entity);
        Task<User> Update(User entity);
        Task<User> Delete(User entity);
        Task<bool> Exists(int id);
        Task<bool> Exists(string email);
        
    }
}