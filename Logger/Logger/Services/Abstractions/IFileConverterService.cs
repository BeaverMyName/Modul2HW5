using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Configs;

namespace Logger.Services.Abstractions
{
    public interface IFileConverterService
    {
        public Config ConvertFileToConfig(string configFile);
        public string ConvertObjectToString(object obj);
    }
}
