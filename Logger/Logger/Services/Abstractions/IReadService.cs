using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Services.Abstractions
{
    public interface IReadService
    {
        public string Read(string path);
    }
}
