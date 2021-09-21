using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Configs
{
    public class LoggerConfig
    {
        public int LineSeparator { get; init; }
        public string TimeFormat { get; init; }
        public string DirectoryPath { get; init; }
        public string BackUpDirectoryPath { get; init; }
        public string FileName { get; init; }
        public string FileExtension { get; init; }
    }
}
