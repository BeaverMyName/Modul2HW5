using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Configs;

namespace Logger.Services.Abstractions
{
    public interface IConfigService
    {
        public Config Config { get; }
        public LoggerConfig LoggerConfig { get; }
        public DirectoryConfig DirectoryConfig { get; }
    }
}
