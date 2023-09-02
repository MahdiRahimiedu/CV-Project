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
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        private readonly CVDbContext _context;

        public SkillRepository(CVDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> UpdatePrioritiesAsync(List<int> ids)
        {
            try
            {
                var lists = new List<Skill>();
                for (int i = 0; i < ids.Count; i++)
                {
                    var item = await _context.Skills.FirstOrDefaultAsync(p => p.Id == ids[i]);
                    if (item != null)
                    {
                        item.Priority = i + 1;
                        lists.Add(item);
                    }
                }
                _context.Skills.UpdateRange(lists);
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
            if (await _context.Skills.AnyAsync())
                return await _context.Skills.MaxAsync(p => p.Priority) + 1;
            return 1;
        }
    }
}
