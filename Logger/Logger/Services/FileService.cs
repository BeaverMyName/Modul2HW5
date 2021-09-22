using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Services.Abstractions;

namespace Logger.Services
{
    public class FileService : IFileService
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }

        public void Write(string text, StreamWriter streamWriter)
        {
            streamWriter.WriteLine(text);
            streamWriter.Flush();
        }
    }
}
