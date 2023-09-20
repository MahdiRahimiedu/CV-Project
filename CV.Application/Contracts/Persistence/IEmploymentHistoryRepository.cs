﻿using CV.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Contracts.Persistence
{
    public interface IEmploymentHistoryRepository : IGenericRepository<EmploymentHistory>
    {
        Task<bool> UpdatePrioritiesAsync(List<int> ids);
        Task<int> PriorityMaxAsync();
        Task<List<EmploymentHistory>> GetAllSortedPriority();
    }
}
