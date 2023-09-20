﻿using CV.Application.Contracts.Persistence;
using CV.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Persistence.Repositories
{
    public class EducationRepository : GenericRepository<Education>, IEducationRepository
    {
        private readonly CVDbContext _context;

        public EducationRepository(CVDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> UpdatePrioritiesAsync(List<int> ids)
        {
            try
            {
                var lists = new List<Education>();
                for (int i = 0; i < ids.Count; i++)
                {
                    var item = await _context.Educations.FirstOrDefaultAsync(p => p.Id == ids[i]);
                    if (item != null)
                    {
                        item.Priority = i + 1;
                        lists.Add(item);
                    }
                }
                _context.Educations.UpdateRange(lists);
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
            if (await _context.Educations.AnyAsync())
                return await _context.Educations.MaxAsync(p => p.Priority) + 1;
            return 1;
        }
        public async Task<List<Education>> GetAllSortedPriority()
        {
            return await _context.Educations.OrderBy(x => x.Priority).ToListAsync();
        }

        public async Task<bool> ChangeImageAsync(int id, string img)
        {
            var education = await GetByIdAsync(id);

            if(education == null) return false;

            education.Img = img;

            try
            {
                await UpdateAsync(education);
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }
    }
}
