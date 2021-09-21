using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Services.Abstractions;

namespace Logger.Services
{
    public class FileReadService : IReadService, IFileReadService
    {
        public string Read(string path)
        {
            return ReadFromFile(path);
        }

        public string ReadFromFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
