using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Configs;
using Logger.Services.Abstractions;
using Logger.Providers.Abstractions;
using Newtonsoft.Json;

namespace Logger.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigProvider _configProvider;
        private readonly Config _config;

        public ConfigService(
            IConfigProvider configProvider)
        {
            _configProvider = configProvider;
            _config = _configProvider.Config;
        }

        public Config Config => _config;
        public LoggerConfig LoggerConfig => _config.LoggerConfig;
        public DirectoryConfig DirectoryConfig => _config.DirectoryConfig;
    }
}
