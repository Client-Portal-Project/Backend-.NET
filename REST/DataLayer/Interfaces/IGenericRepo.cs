using System.Collections.Generic;
using System.Threading.Tasks;

namespace REST.DataLayer.Interfaces
{
    public interface IGenericRepo<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int query);
        void Save();
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}