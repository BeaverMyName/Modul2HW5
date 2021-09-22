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
                .AddTransient<IFileConverterService, JsonFileConverterService>()
                .AddTransient<IConfigProvider, ConfigProvider>()
                .AddSingleton<IConfigService, ConfigService>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<IDirectoryService, DirectoryService>()
                .AddTransient<Application>()
                .BuildServiceProvider();

            _application = serviceProvider.GetService<Application>();
            _application.Run();
        }
    }
}
