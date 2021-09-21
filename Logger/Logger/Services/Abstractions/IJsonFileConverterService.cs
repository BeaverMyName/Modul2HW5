using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Configs;

namespace Logger.Services.Abstractions
{
    public interface IJsonFileConverterService
    {
        public Config ConvertJsonFileToConfig(string configFile);
        public string ConvertObjectToJson(object obj);
    }
}
