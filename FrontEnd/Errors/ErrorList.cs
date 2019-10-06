using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Errors
{
    public class ErrorList
    {
        public List<string> ErrorCodes { get; set; }

        public ErrorList()
        {
            ErrorCodes = new List<string>();
        }
    }
}
