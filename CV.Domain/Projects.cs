using CV.Domain.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Domain
{
    public class Projects : BaseEntityDomein
    {
        public string Name { get; set; }
        public string Applicant { get; set; }
        public string Date { get; set; }
        public string Img { get; set; }
    }
}
