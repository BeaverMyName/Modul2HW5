using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Configs;

namespace Logger.Providers.Abstractions
{
    public interface IConfigProvider
    {
        public Config Config { get; }
        public DirectoryConfig DirectoryConfig { get; }
        public LoggerConfig LoggerConfig { get; }
    }
}
