using CV.Application.Contracts.Persistence;
using CV.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Persistence.Repositories
{
    public class EmploymentHistoryRepository : GenericRepository<EmploymentHistory>, IEmploymentHistoryRepository
    {
        private readonly CVDbContext _context;

        public EmploymentHistoryRepository(CVDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> UpdatePrioritiesAsync(List<int> ids)
        {
            try
            {
                var lists = new List<EmploymentHistory>();
                for (int i = 0; i < ids.Count; i++)
                {
                    var item = await _context.EmploymentHistorys.FirstOrDefaultAsync(p => p.Id == ids[i]);
                    if (item != null)
                    {
                        item.Priority = i + 1;
                        lists.Add(item);
                    }
                }
                _context.EmploymentHistorys.UpdateRange(lists);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<int> PriorityMaxAsync()
        {
            if (await _context.EmploymentHistorys.AnyAsync())
                return await _context.EmploymentHistorys.MaxAsync(p => p.Priority) + 1;
            return 1;
        }
        public async Task<List<EmploymentHistory>> GetAllSortedPriority()
        {
            return await _context.EmploymentHistorys.OrderBy(x => x.Priority).ToListAsync();
        }
    }
}
