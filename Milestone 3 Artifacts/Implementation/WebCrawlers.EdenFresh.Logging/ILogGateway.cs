
using System.Data;
namespace WebCrawlers.EdenFresh.Logging

{
    interface ILogGateway
    {
        public Boolean WriteLog(int userId, DateTime timeStamp, LogWriter.LogLevel logLevel, LogWriter.Category category, string message);
        public Boolean ReadLog(int logId);
        public Boolean DeleteLog(int logId);
    }
}
