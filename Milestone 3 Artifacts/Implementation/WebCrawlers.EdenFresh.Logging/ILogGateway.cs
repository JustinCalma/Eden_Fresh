namespace WebCrawlers.EdenFresh.Logging

{
    interface ILogGateway
    {
        public Boolean Write(int userId, DateTime timeStamp, LogLevel logLevel, Category category, string message);
        public Boolean ReadLog(int logId);
        public Boolean UpdateLog(int logId, LogWriter replacementLog);
        public Boolean DeleteLog(int logId);
    }
}