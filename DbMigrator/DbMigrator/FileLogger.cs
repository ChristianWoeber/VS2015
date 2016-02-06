using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrator
{
    public class FileLogger : ILogger
    {
        private readonly string _path;

        public FileLogger(string path)
        {
            _path = path;
        }


        public void LogError(string message)
        {
            var errorType = MessageType.ERROR;
            Log(message, errorType);
        }

        public void LogInfo(string message)
        {
            var errorType = MessageType.INFO;
            Log(message, errorType);
        }

        private void Log(string message, MessageType messageType)
        {
            using (var streamWriter = new StreamWriter(_path,true))
            {
                streamWriter.WriteLine(messageType +": "+ message);
            }
        }
    }
}
