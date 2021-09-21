using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Services.Abstractions;

namespace Logger.Services
{
    public class FileWriteService : IFileWriteService, IWriteService
    {
        public void Write(string text, string path)
        {
            WriteInFile(text, path);
        }

        public void WriteInFile(string text, string path)
        {
            File.WriteAllText(path, text);
        }
    }
}
