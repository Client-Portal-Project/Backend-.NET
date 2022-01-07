using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {

        private readonly BatchesDBContext _context;

        public GenericRepo(BatchesDBContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetById(int query)
        {
            return await _context.Set<TEntity>().FindAsync(query);
        }

        // update modifies memory, no changes to db occurs until SaveChanges()
        // entity should always be found, you're updating an existing record
        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        // Save is implemented separately so you can perform multiple ops with one
        // db query
        public async Task<string> Save()
        {
            await _context.SaveChangesAsync();
            return "Changes saved";
        }
    }
}