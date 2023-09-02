using CV.Application.DTOs.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.EmploymentHistories
{
    public class EditEmploymentHistoryDto : BaseDto , IEmploymentHistoryDto
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Compony { get; set; }
    }
}
