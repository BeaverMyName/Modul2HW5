using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Services.Abstractions;

namespace Logger.Services
{
    public class FileStreamWriterService : IFileStreamWriterService
    {
        private StreamWriter _streamWriter;

        public void WriteInFile(string text, string path)
        {
            if (_streamWriter == null)
            {
                SetStreamWriter(path);
            }

            _streamWriter.WriteLine(text);
        }

        private void SetStreamWriter(string path)
        {
            _streamWriter = new StreamWriter(path);
        }
    }
}
