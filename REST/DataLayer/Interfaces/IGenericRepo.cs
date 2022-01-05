using System.Collections.Generic;
using System.Threading.Tasks;

namespace REST.DataLayer.Interfaces
{
    public interface IGenericRepo<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int query);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        Task<string> Save();
    }
}