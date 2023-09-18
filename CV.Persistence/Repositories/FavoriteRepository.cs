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
    public class FavoriteRepository : GenericRepository<Favorite>, IFavorioteRepository
    {
        private readonly CVDbContext _context;

        public FavoriteRepository(CVDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task DeleteAllAsync(List<int> ids)
        {
            List<Favorite> favorites = new List<Favorite>();
            foreach (int id in ids)
            {
                favorites.Add(await GetByIdAsync(id));
            }
            _context.Favorites.RemoveRange(favorites);
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
