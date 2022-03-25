using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserCalc : IUserCalc
    {
        private readonly IGenericRepo<User> _repo;
        public UserCalc(IGenericRepo<User> repo)
        {
            _repo = repo;
        }

        public async Task<User> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _repo.GetByEmail(email);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<User> Add(User entity)
        {
            return await _repo.Add(entity);
        }

        public async Task<User> Update(User entity)
        {
            return await _repo.Update(entity);
        }

        public async Task<User> Delete(User entity)
        {
            return await _repo.Delete(entity);
        }
        public async Task<User> Delete(int id)
        {
            return await _repo.Delete(GetById(id));
        }

        public async Task<bool> Exists(int id)
        {
            return await _repo.Exists(id);
        }

        public async Task<bool> Exists(string email)
        {
            return await _repo.Exists(email);
        }
    }
}
