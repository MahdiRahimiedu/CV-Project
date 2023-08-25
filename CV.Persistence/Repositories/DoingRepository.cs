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
        public DoingRepository(CVDbContext context) : base(context)
        {
        }
    }
}
