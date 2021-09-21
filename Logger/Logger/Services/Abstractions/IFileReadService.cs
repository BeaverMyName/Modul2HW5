using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Services.Abstractions
{
    public interface IFileReadService
    {
        public string ReadFromFile(string path);
    }
}
