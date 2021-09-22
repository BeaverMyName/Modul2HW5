using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Services.Abstractions
{
    public interface IFileService
    {
        public void Write(string text, StreamWriter streamWriter);
        public string Read(string path);
    }
}
