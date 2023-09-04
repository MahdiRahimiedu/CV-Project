using CV.Application.Contracts.Persistence;
using CV.Application.Response;
using CV.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Persistence.Repositories
{
    public class ContactMeRepository : GenericRepository<ContactMe>, IContactMeRepository
    {
        private readonly CVDbContext _context;

        public ContactMeRepository(CVDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task ChengeSeenStatusAsync(ContactMe contactMe)
        {
            contactMe.Seen = true;
            contactMe.DateSeen = DateTime.Now;

            DateTime d = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();
            contactMe.DateSeenIr = string.Format("{0}/{1}/{2}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d));

            _context.Update(contactMe);
            await _context.SaveChangesAsync();
        }

        public async Task ChengeStarStatusAsync(ContactMe contactMe)
        {
            contactMe.Star = !contactMe.Star;
            _context.Update(contactMe);
            await _context.SaveChangesAsync();
        }
    }
}
