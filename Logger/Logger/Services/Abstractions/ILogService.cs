using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Enums;

namespace Logger.Services.Abstractions
{
    public interface ILogService
    {
        public string Log { get; }
        public IConfigService ConfigService { get; }
        public void WriteInfoLog(string log);
        public void WriteWarningLog(string log);
        public void WriteErrorLog(string log);
        public void SaveLog();
    }
}
