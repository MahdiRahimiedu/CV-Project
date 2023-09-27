using CV.Domain.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Domain
{
    public class AboutUs :BaseEntityDomein
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? AbouteMe { get; set; }
        public string? CupCuffee { get; set; }
        public string? CompletedProject { get; set; }
    }
}
