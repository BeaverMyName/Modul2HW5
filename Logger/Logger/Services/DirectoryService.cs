using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Services.Abstractions;
using Logger.Configs;

namespace Logger.Services
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IConfigService _configService;

        public DirectoryService(
            IConfigService configService)
        {
            _configService = configService;
        }

        public DirectoryConfig DirectoryConfig => _configService.DirectoryConfig;

        public void CreateDirectory()
        {
            var directoryInfo = new DirectoryInfo(DirectoryConfig.DirectoryPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }

        public void ClearDirectory()
        {
            var files = Directory.GetFiles(DirectoryConfig.DirectoryPath);

            if (!IsEnoughSpace(files))
            {
                for (var i = 0; i < files.Length - DirectoryConfig.Capacity + 1; i++)
                {
                    File.Delete(files[i]);
                }
            }
        }

        private bool IsEnoughSpace(string[] files)
        {
            if (files.Length >= DirectoryConfig.Capacity)
            {
                return false;
            }

            return true;
        }
    }
}
