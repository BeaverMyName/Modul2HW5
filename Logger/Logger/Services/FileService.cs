using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Services.Abstractions;

namespace Logger.Services
{
    public class FileService : IReadWriteService
    {
        private readonly IReadService _readerService;
        private readonly IWriteService _writerService;

        public FileService(
            IReadService readerService,
            IWriteService writerService)
        {
            _readerService = readerService;
            _writerService = writerService;
        }

        public IReadService ReaderService => _readerService;
        public IWriteService WriterService => _writerService;
    }
}
