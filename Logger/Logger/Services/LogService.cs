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
        private readonly IWriteService _writeService;
        private readonly StringBuilder _log;
        private readonly IConfigService _configService;

        public LogService(
            IWriteService writeService,
            IConfigService configService)
        {
            _log = new StringBuilder();
            _writeService = writeService;
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

        public void SaveLog()
        {
            _writeService.Write(Log, $"{_configService.LoggerConfig.DirectoryPath}{DateTime.UtcNow.ToString(_configService.LoggerConfig.FileName)}{_configService.LoggerConfig.FileExtension}");
        }

        private void WriteLog(string log, LogType logType)
        {
            var formatLog = $"{DateTime.UtcNow.ToString(_configService.LoggerConfig.TimeFormat)}: {logType}: {log}";
            _log.AppendLine(formatLog);
        }
    }
}
