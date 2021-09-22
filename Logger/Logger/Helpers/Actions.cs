using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Exceptions;
using Logger.Services;
using Logger.Services.Abstractions;

namespace Logger.Helpers
{
    public class Actions
    {
        private readonly ILogService _logService;

        public Actions(
            ILogService logService)
        {
            _logService = logService;
        }

        public bool GetInfo()
        {
            _logService.WriteInfoLog($"Start method: GetInfo");
            return true;
        }

        public bool GetWarning()
        {
            throw new BusinessException("Skipped logic in method");
        }

        public bool GetError()
        {
            throw new Exception("I broke a logic");
        }
    }
}
