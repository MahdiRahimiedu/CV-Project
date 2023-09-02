using CV.Application.Contracts.Persistence;
using CV.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Persistence.Repositories
{
    public class FavoriteRepository : GenericRepository<Favorite>, IFavorioteRepository
    {
        public FavoriteRepository(CVDbContext context) : base(context)
        {
        }
    }
}
