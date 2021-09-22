using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Providers.Abstractions;
using Logger.Configs;
using Logger.Services.Abstractions;

namespace Logger.Providers
{
    public class ConfigProvider : IConfigProvider
    {
        private readonly string _fileName;
        private readonly Config _config;
        private readonly IReadWriteService _readerWriterService;
        private readonly IFileConverterService _fileConverterService;

        public ConfigProvider(
            IReadWriteService readerWriterService,
            IFileConverterService fileConverterService)
        {
            _readerWriterService = readerWriterService;
            _fileConverterService = fileConverterService;
            _fileName = "config.json";
            _config = _fileConverterService.ConvertFileToConfig(_readerWriterService.ReaderService.Read(_fileName));
        }

        public Config Config => _config;
        public DirectoryConfig DirectoryConfig => _config.DirectoryConfig;
        public LoggerConfig LoggerConfig => _config.LoggerConfig;
    }
}
