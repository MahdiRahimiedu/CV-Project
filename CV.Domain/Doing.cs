using CV.Domain.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Domain
{
    public class Doing : BaseEntityDomein
    {
        public string Title { get; set; }
        public string? Location { get; set; }
        public string Detail { get; set; }
    }
}
