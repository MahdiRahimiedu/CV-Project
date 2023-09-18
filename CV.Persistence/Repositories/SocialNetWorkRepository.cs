using CV.Application.Contracts.Persistence;
using CV.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Persistence.Repositories
{
    public class SocialNetWorkRepository : GenericRepository<SocialsNetWork>, ISocialNetWorkRepository
    {
        private readonly CVDbContext _context;

        public SocialNetWorkRepository(CVDbContext context) : base(context)
        {
            _context = context;

        }

        public async Task DeleteAllAsync(List<int> ids)
        {
            List<SocialsNetWork> socialNetWork = new List<SocialsNetWork>();
            foreach (int id in ids)
            {
                socialNetWork.Add(await GetByIdAsync(id));
            }
            _context.SocialsNetWorks.RemoveRange(socialNetWork);
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
