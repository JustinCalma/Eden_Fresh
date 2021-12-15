
namespace WebCrawlers.EdenFresh.Logging
{
    class Demo
    {
        
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=logging;Integrated Security=True;Pooling=False";
            ILogGateway dao = new MSSQLLogGateway(connectionString);
            LogWriter writer = new LogWriter(dao);
           // writer.Write(1, LogWriter.LogLevel.Info, LogWriter.Category.Data, "LogTesting");
        }

    }
}
