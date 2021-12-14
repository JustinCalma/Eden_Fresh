namespace WebCrawlers.EdenFresh.Logging

{
    interface ILogGateway
    {
        public Boolean Write(int userId, DateTime timeStamp, LogWriter.LogLevel logLevel, LogWriter.Category category, string message);
        public Boolean ReadLog(int logId);
        public Boolean UpdateLog(int logId, LogWriter replacementLog);
        public Boolean DeleteLog(int logId);
    }
}