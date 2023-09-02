using CV.Application.Response;
using CV.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Contracts.Persistence
{
    public interface IContactMeRepository : IGenericRepository<ContactMe>
    {
        public Task ChengeSeenStatusAsync(ContactMe contactMe);
        public Task ChengeStarStatusAsync(ContactMe contactMe);
    }
}
