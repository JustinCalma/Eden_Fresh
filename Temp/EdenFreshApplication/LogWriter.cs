using System.Diagnostics;

namespace EdenFreshApplication
{
    class LogWriter
    {
        public enum LogLevel { Info, Debug, Warning, Error }
        public enum Category { View, Business, Server, Data, DataStore }


        public int userId { get; set; }
        public DateTime timeStamp { get; set; }
        public LogLevel logLevel { get; set; }
        public Category category { get; set; }
        public string message { get; set; }



        private Stopwatch stopwatch = new Stopwatch();
        private String timeDate = DateTime.Now.ToString("yyyy-MM-dd HH:MM:SS");
        private Boolean writeSuccessful = false;
      
        public LogWriter() 
        {
        }
        public LogWriter(int userId, DateTime timeStamp, LogLevel logLevel, Category category, string message)
        {
            this.userId = userId;
            this.timeStamp = timeStamp;
            this.logLevel = logLevel;
            this.category = category;
            this.message = message;

        }
        public Boolean Write(int userId, DateTime timeStamp, LogLevel logLevel, Category category, string message)
        {
            stopwatch.Start();
            MSSQLLogGateway dataAccess = new MSSQLLogGateway();
            writeSuccessful = dataAccess.Write(userId, timeStamp, logLevel,category,message);
            stopwatch.Stop();
            return (writeSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
        }

        public Boolean Write()
        {
            stopwatch.Start();
            MSSQLLogGateway dataAccess = new MSSQLLogGateway();
            writeSuccessful = dataAccess.Write(userId, timeStamp, logLevel, category, message);
            stopwatch.Stop();
            return (writeSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
        }
       

       

    }
}
