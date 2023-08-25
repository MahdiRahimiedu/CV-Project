using CV.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Persistence
{
    public class CVDbContext : DbContext
    {
        public CVDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Doing> Doings { get; set; }
    }
}
