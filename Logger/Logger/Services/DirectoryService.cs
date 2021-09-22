using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Services.Abstractions;
using Logger.Configs;
using Logger.Helpers;

namespace Logger.Services
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IConfigService _configService;
        private readonly DirectoryInfo _directoryInfo;

        public DirectoryService(
            IConfigService configService)
        {
            _configService = configService;
            _directoryInfo = new DirectoryInfo(DirectoryConfig.DirectoryPath);
        }

        public DirectoryConfig DirectoryConfig => _configService.DirectoryConfig;

        public void CreateDirectory()
        {
            if (!_directoryInfo.Exists)
            {
                _directoryInfo.Create();
            }
        }

        public void ClearDirectory()
        {
            var files = _directoryInfo.GetFiles();

            if (!IsEnoughSpace(files))
            {
                Array.Sort(files, new FileCreationTimeComparer());
                for (var i = 0; i < files.Length - DirectoryConfig.Capacity + 1; i++)
                {
                    File.Delete(files[i].FullName);
                }
            }
        }

        private bool IsEnoughSpace(FileInfo[] files)
        {
            if (files.Length >= DirectoryConfig.Capacity)
            {
                return false;
            }

            return true;
        }
    }
}
