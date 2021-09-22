using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Services;
using Logger.Services.Abstractions;
using Logger.Exceptions;
using Logger.Helpers;

namespace Logger
{
    public class Application
    {
        private readonly ILogService _logService;
        private readonly IFileConverterService _fileConverterService;
        private readonly IDirectoryService _directoryService;

        public Application(
            ILogService logService,
            IFileConverterService fileConverterService,
            IDirectoryService directoryService)
        {
            _logService = logService;
            _fileConverterService = fileConverterService;
            _directoryService = directoryService;
        }

        public void Run()
        {
            _directoryService.CreateDirectory();
            _directoryService.ClearDirectory();

            var actions = new Actions(_logService);

            var random = new Random();

            for (var i = 0; i < 100; i++)
            {
                try
                {
                    var result = random.Next(3) switch
                    {
                        0 => actions.GetInfo(),
                        1 => actions.GetWarning(),
                        2 => actions.GetError(),
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
