using CV.Application.DTOs.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.ContactMes
{
    public class ChangeNoteContactMeDto:BaseDto
    {
        public string Note { get; set; }
    }
}
