﻿using CV.Application.Contracts.Persistence;
using CV.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Persistence.Repositories
{
    public class ServicRepository : GenericRepository<Servic>, IServicRepository
    {
        public ServicRepository(CVDbContext context) : base(context)
        {
        }
    }
}
