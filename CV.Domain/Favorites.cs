using CV.Domain.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Domain
{
    public class Favorites : BaseEntityDomein
    {
        public string Name { get; set; }
        public string? Detail { get; set; }
    }
}
