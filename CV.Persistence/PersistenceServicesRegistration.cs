using CV.Application.Contracts.Persistence;
using CV.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CVDbContext>(options =>
            {

                options.UseSqlServer(configuration.GetConnectionString("CVConnectionString"));
                //options.UseSqlServer("Data Source = LAPTOP - 8KB21INC; Initial Catalog = CVDb; Integrated Security = True");

            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IContactMeRepository, ContactMeRepository>();
            services.AddScoped<IDoingRepository, DoingRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IEmploymentHistoryRepository, EmploymentHistoryRepository>();
            services.AddScoped<IFavorioteRepository, FavoriteRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IServicRepository, ServicRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ISocialNetWorkRepository, SocialNetWorkRepository>();



            return services;
        }
    }
}
