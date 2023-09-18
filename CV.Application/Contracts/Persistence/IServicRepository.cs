using CV.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Contracts.Persistence
{
    public interface IServicRepository : IGenericRepository<Servic>
    {
        Task<bool> UpdatePrioritiesAsync(List<int> ids);
        Task<int> PriorityMaxAsync();
        Task DeleteAllAsync(List<int> ids);
        Task<bool> ExistListAsync(List<int> ids);
        Task<List<Servic>> GetAllSortedPriority();
    }
}
