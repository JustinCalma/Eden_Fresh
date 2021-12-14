using System;
using System.Diagnostics;

namespace WebCrawlers.EdenFresh.Logging
{
    public enum LogLevel { Info, Debug, Warning, Error }
    public enum Category { View, Business, Server, Data, DataStore }
    class LogWriter
    {
        private Stopwatch stopwatch;
        private ILogGateway logConnection;
      
        public LogWriter(ILogGateway conn) 
        {
            this.stopwatch = new Stopwatch();
            this.logConnection = conn;
        }

        public Boolean Write(int userId, DateTime timeStamp, LogLevel logLevel, Category category, string message)
        {
            stopwatch.Restart();
            stopwatch.Start();
            bool writeSuccessful = logConnection.Write(userId, timeStamp, logLevel, category, message);
            stopwatch.Stop();
            return (writeSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
        }
    }
}