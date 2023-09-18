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
    public class ServicRepository : GenericRepository<Servic>, IServicRepository
    {
        private readonly CVDbContext _context;

        public ServicRepository(CVDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> UpdatePrioritiesAsync(List<int> ids)
        {
            try
            {
                var lists = new List<Servic>();
                for (int i = 0; i < ids.Count; i++)
                {
                    var item = await _context.Servics.FirstOrDefaultAsync(p => p.Id == ids[i]);
                    if (item != null)
                    {
                        item.Priority = i + 1;
                        lists.Add(item);
                    }
                }
                _context.Servics.UpdateRange(lists);
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
            if (await _context.Servics.AnyAsync())
                return await _context.Servics.MaxAsync(p => p.Priority) + 1;
            return 1;
        }

        public async Task DeleteAllAsync(List<int> ids)
        {
            List<Servic> servisec = new List<Servic>();
            foreach (int id in ids)
            {
                servisec.Add(await GetByIdAsync(id));
            }
            _context.Servics.RemoveRange(servisec);
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

        public async Task<List<Servic>> GetAllSortedPriority()
        {
            return await _context.Servics.OrderBy(x => x.Priority).ToListAsync();
        }
    }
}
