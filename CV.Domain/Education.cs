using CV.Domain.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Domain
{
    public class Education : BaseEntityDomein
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string? Img { get; set; }
        public int Priorty { get; set; }
    }
}
