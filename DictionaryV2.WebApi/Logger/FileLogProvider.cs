using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DictionaryV2.WebApi.Logger {
    public class FileLogProvider : ILoggerProvider {
        public ILogger CreateLogger(string category) {
            return new FileLogger();
        }
        public void Dispose() {

        }
    }
}
