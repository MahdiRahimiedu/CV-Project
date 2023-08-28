using CV.Application.DTOs.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.ContactMes
{
    public class ContactMeDto : BaseDto , IContactMeDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MessageTitle { get; set; }
        public string Message { get; set; }
        public bool Seen { get; set; }
        public DateTime? DateSeen { get; set; }
        public string? DateSeenIr { get; set; }
        public DateTime DateCreated { get; set; }
        public string DateCreatedIr { get; set; }
        public bool Star { get; set; }
        public string? Note { get; set; }
    }
}
