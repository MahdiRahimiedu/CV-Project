using CV.Application.DTOs.Skillss;
using CV.Domain;

namespace CV.Application.Contracts.Persistence
{
    public interface ISkillRepository : IGenericRepository<Skill>
    {
        Task<bool> UpdatePrioritiesAsync(List<int> ids);
        Task<int> PriorityMaxAsync();
        Task DeleteAllAsync(List<int> ids);
        Task<bool> ExistListAsync(List<int> ids);
        Task<List<Skill>> GetAllSortedPriority();
    }
}
