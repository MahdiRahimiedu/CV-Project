using CV.Domain.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Domain
{
    public class EmploymentHistory : BaseEntityDomein
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Compony { get; set; }
        public int Priorty { get; set; }
    }
}
