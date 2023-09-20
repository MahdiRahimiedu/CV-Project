using CV.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Contracts.Persistence
{
    public interface IEducationRepository : IGenericRepository<Education>
    {
        Task<bool> UpdatePrioritiesAsync(List<int> ids);
        Task<int> PriorityMaxAsync();
        Task<List<Education>> GetAllSortedPriority();
        Task<bool> ChangeImageAsync(int id , string img);

    }
}
