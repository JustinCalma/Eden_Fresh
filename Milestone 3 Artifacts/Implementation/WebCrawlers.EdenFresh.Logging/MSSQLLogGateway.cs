﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlers.EdenFresh.Logging
{
    class MSSQLLogGateway : ILogGateway
    {
        public bool DeleteLog(int logId)
        {
            throw new NotImplementedException();
        }

        public bool ReadLog(int logId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLog(int logId, LogWriter replacementLog)
        {
            throw new NotImplementedException();
        }

        public bool Write(int userId, DateTime timeStamp, LogLevel logLevel, Category category, string message)
        {
            throw new NotImplementedException();
        }
    }
}