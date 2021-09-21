using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Configs;

namespace Logger.Services.Abstractions
{
    public interface IDirectoryService
    {
        public DirectoryConfig DirectoryConfig { get; }
        public void ClearDirectory();
        public void CreateDirectory();
    }
}
