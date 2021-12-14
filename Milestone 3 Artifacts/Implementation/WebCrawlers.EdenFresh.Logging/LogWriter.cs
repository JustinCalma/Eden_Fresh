
using System;
using System.Diagnostics;

namespace WebCrawlers.EdenFresh.Logging
{
    class LogWriter
    {
        public enum LogLevel { Info, Debug, Warning, Error }
        public enum Category { View, Business, Server, Data, DataStore }
        public LogLevel logLevel { get; set; }
        public Category category { get; set; }


        private Stopwatch stopwatch;
        private MSSQLLogGateway logConnection;
      
        public LogWriter() 
        {
            this.stopwatch = new Stopwatch();
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
