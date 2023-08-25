using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Delete(T entity);
        Task Delete(int id);
        Task Update(T entity);
        Task<bool> Exist(int id);
    }
}
