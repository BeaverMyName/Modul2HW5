using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Services.Abstractions;
using Logger.Configs;
using Newtonsoft.Json;

namespace Logger.Services
{
    public class JsonFileConverterService : IFileConverterService, IJsonFileConverterService
    {
        public Config ConvertFileToConfig(string configFile)
        {
            return ConvertJsonFileToConfig(configFile);
        }

        public Config ConvertJsonFileToConfig(string configFile)
        {
            var config = JsonConvert.DeserializeObject<Config>(configFile);
            return config;
        }

        public string ConvertObjectToString(object obj)
        {
            return ConvertObjectToJson(obj);
        }

        public string ConvertObjectToJson(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return json;
        }
    }
}
