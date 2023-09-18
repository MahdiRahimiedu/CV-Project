using CV.Application.Contracts.Persistence;
using CV.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Persistence.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly CVDbContext _context;

        public ProjectRepository(CVDbContext context) : base(context)
        {
            _context = context;

        }

        public async Task DeleteAllAsync(List<int> ids)
        {
            List<Project> projects = new List<Project>();
            foreach (int id in ids)
            {
                projects.Add(await GetByIdAsync(id));
            }
            _context.Projects.RemoveRange(projects);
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
