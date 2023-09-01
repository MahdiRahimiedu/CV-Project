using CV.Application.DTOs.Command;
using CV.Domain.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.ContactMes
{
    public class EditContactMeDto : BaseDto , IContactMeDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MessageTitle { get; set; }
        public string Message { get; set; }
    }
}
