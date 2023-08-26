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
        public DbSet<ContactMe> ContactMes { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<EmploymentHistory> EmploymentHistorys { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Servic> Servics { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialsNetWork> SocialsNetWorks { get; set; }
    }
}
