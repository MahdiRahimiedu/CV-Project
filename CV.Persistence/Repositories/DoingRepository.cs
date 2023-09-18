using CV.Application.Contracts.Persistence;
using CV.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Persistence.Repositories
{
    public class DoingRepository : GenericRepository<Doing>, IDoingRepository
    {
        private readonly CVDbContext _context;

        public DoingRepository(CVDbContext context) : base(context)
        {
            _context = context;

        }

        public async Task DeleteAllAsync(List<int> ids)
        {
            List<Doing> doings = new List<Doing>();
            foreach (int id in ids)
            {
                doings.Add(await GetByIdAsync(id));
            }
            _context.Doings.RemoveRange(doings);
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

    }
}
