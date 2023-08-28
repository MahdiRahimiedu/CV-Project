using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Response
{
    public class BaseCommandResponse
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Succses { get; set; }
        public List<string> Erorrs { get; set; }

    }
}
