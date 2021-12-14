using System;
using System.Diagnostics;

namespace WebCrawlers.EdenFresh.Logging
{
    public enum LogLevel { Info, Debug, Warning, Error }
    public enum Category { View, Business, Server, Data, DataStore }
    public class LogWriter
    {
        private Stopwatch stopwatch;
        private ILogGateway logConnection;
      
        public LogWriter(ILogGateway conn) 
        {
            this.stopwatch = new Stopwatch();
            this.logConnection = conn;
        }

        public Boolean Write(int userId, LogLevel logLevel, Category category, string message)
        {
            stopwatch.Restart();
            stopwatch.Start();
            DateTime timestamp = DateTime.Now;
            bool writeSuccessful = logConnection.WriteLog(userId, timestamp, logLevel, category, message);
            stopwatch.Stop();
            return (writeSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
        }
    }
}