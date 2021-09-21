using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Services;
using Logger.Services.Abstractions;
using Logger.Exceptions;

namespace Logger
{
    public class Application
    {
        private readonly ILogService _logService;
        private readonly IActionService _actionService;
        private readonly IFileConverterService _fileConverterService;
        private readonly IDirectoryService _directoryService;
        private readonly Random _random;

        public Application(
            ILogService logService,
            IActionService actionService,
            IFileConverterService fileConverterService,
            IDirectoryService directoryService)
        {
            _logService = logService;
            _actionService = actionService;
            _fileConverterService = fileConverterService;
            _directoryService = directoryService;
            _random = new Random();
        }

        public void Run()
        {
            _directoryService.CreateDirectory();
            _directoryService.ClearDirectory();
            for (var i = 0; i < 100; i++)
            {
                try
                {
                    var result = _random.Next(3) switch
                    {
                        0 => _actionService.GetInfo(),
                        1 => _actionService.GetWarning(),
                        2 => _actionService.GetError(),
                        _ => throw new ArgumentException()
                    };
                }
                catch (BusinessException businessException)
                {
                    _logService.WriteWarningLog($"Action got this custom exception: {businessException.Message}");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Method doesn't exist!");
                }
                catch (Exception exception)
                {
                    _logService.WriteErrorLog($"Action failed by reason: {_fileConverterService.ConvertObjectToString(exception)}");
                }
            }
        }
    }
}
