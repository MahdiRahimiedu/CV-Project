using CV.Application.Contracts.Persistence;
using CV.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Persistence.Repositories
{
    public class EducationRepository : GenericRepository<Education>, IEducationRepository
    {
        public EducationRepository(CVDbContext context) : base(context)
        {
        }
    }
}
