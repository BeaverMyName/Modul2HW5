using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Logger.Services.Abstractions;
using Logger.Providers.Abstractions;
using Logger.Services;
using Logger.Providers;

namespace Logger
{
    public class Starter
    {
        private Application _application;

        public void StartApplication()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILogService, LogService>()
                .AddTransient<IReadService, FileReadService>()
                .AddTransient<IFileConverterService, JsonFileConverterService>()
                .AddTransient<IActionService, ActionService>()
                .AddTransient<IConfigProvider, ConfigProvider>()
                .AddSingleton<IConfigService, ConfigService>()
                .AddTransient<IReadWriteService, FileService>()
                .AddTransient<IDirectoryService, DirectoryService>()
                .AddTransient<IWriteService, FileWriteService>()
                .AddTransient<Application>()
                .BuildServiceProvider();

            _application = serviceProvider.GetService<Application>();
            _application.Run();
        }
    }
}
