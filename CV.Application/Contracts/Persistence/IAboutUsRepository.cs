using CV.Application.DTOs.AboutUs;
using CV.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Contracts.Persistence
{
    public interface IAboutUsRepository:IGenericRepository<AboutUs>
    {
        
    }
}
