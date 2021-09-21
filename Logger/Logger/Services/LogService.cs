using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Services.Abstractions;
using Logger.Enums;

namespace Logger.Services
{
    public class LogService : ILogService
    {
        private readonly IFileStreamWriterService _fileStreamWriterService;
        private readonly StringBuilder _log;
        private readonly IConfigService _configService;

        public LogService(
            IFileStreamWriterService fileStreamWriterService,
            IConfigService configService)
        {
            _log = new StringBuilder();
            _fileStreamWriterService = fileStreamWriterService;
            _configService = configService;
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
            _fileStreamWriterService.WriteInFile(formatLog, $"{_configService.LoggerConfig.DirectoryPath}{DateTime.UtcNow.ToString(_configService.LoggerConfig.FileName)}{_configService.LoggerConfig.FileExtension}");
        }
    }
}
