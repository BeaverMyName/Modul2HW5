using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Logger.Services.Abstractions;
using Logger.Enums;

namespace Logger.Services
{
    public class LogService : ILogService
    {
        private readonly IFileService _fileService;
        private readonly StringBuilder _log;
        private readonly IConfigService _configService;
        private readonly StreamWriter _streamWriter;

        public LogService(
            IFileService fileService,
            IConfigService configService)
        {
            _log = new StringBuilder();
            _fileService = fileService;
            _configService = configService;
            _streamWriter = new StreamWriter($"{_configService.LoggerConfig.DirectoryPath}{DateTime.UtcNow.ToString(_configService.LoggerConfig.FileName)}{_configService.LoggerConfig.FileExtension}");
        }

        public string Log => _log.ToString();
        public IConfigService ConfigService => _configService;

        public void WriteInfoLog(string log)
        {
            WriteLog(log, LogType.Info);
        }

        public void WriteWarningLog(string log)
        {
            WriteLog(log, LogType.Warning);
        }

        public void WriteErrorLog(string log)
        {
            WriteLog(log, LogType.Error);
        }

        private void WriteLog(string log, LogType logType)
        {
            var formatLog = $"{DateTime.UtcNow.ToString(_configService.LoggerConfig.TimeFormat)}: {logType}: {log}";
            _log.AppendLine(formatLog);
            _fileService.Write(formatLog, _streamWriter);
        }
    }
}
