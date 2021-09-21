using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Exceptions;

namespace Logger.Services.Abstractions
{
    public interface IActionService
    {
        public bool GetInfo();
        public bool GetWarning();
        public bool GetError();
    }
}
