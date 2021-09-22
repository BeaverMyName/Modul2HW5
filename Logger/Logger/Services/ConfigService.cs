using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Configs;
using Logger.Services.Abstractions;
using Newtonsoft.Json;

namespace Logger.Services
{
    public class ConfigService : IConfigService
    {
        private readonly Config _config;
        private readonly IReadWriteService _readerWriterService;
        private readonly IFileConverterService _fileConverterService;
        private readonly string _fileName;

        public ConfigService(
            IReadWriteService readerWriterService,
            IFileConverterService fileConverterService)
        {
            _readerWriterService = readerWriterService;
            _fileConverterService = fileConverterService;
            _fileName = "config.json";
            _config = _fileConverterService.ConvertFileToConfig(_readerWriterService.ReaderService.Read(_fileName));
        }

        public Config Config => _config;
        public LoggerConfig LoggerConfig => _config.LoggerConfig;
        public DirectoryConfig DirectoryConfig => _config.DirectoryConfig;
    }
}
