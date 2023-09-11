using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Skillss;
using CV.Application.Response;
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

        public async Task DeleteAllAsync(List<int> ids)
        {
            List<Skill> skills = new List<Skill>();
            foreach (int id in ids)
            {
                skills.Add(await GetByIdAsync(id));
            }
            _context.Skills.RemoveRange(skills);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> ExistListAsync(List<int> ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    if (!await ExistAsync(id))
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Skill>> GetAllSortedPriority()
        {
            return await _context.Skills.OrderBy(x => x.Priority).ToListAsync();
        }
    }
}
