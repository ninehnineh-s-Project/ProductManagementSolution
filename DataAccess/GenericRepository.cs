using DAOs;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public async Task Add(T entity)
        {
            await GenericDAO<T>.Instance.Add(entity);
        }

        public async Task Delete(T entity)
        {
            await GenericDAO<T>.Instance.Delete(entity);
        }

        public virtual async Task<T> Get(int id)
        {
            return await GenericDAO<T>.Instance.Get(id);
        }

        public  async Task<IEnumerable<T>> GetAll()
        {
            return await GenericDAO<T>.Instance.GetAll();
            
        }

        public async Task Update(T entity)
        {
             await GenericDAO<T>.Instance.Update(entity);
        }
    }
}
