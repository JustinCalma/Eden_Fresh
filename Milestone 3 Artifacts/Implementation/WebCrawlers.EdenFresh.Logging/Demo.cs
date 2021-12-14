
namespace WebCrawlers.EdenFresh.Logging
{
    class Demo
    {
        
        static void Main(string[] args)
        {
            LogWriter writer = new LogWriter();
            writer.Write(1, LogWriter.LogLevel.Info, LogWriter.Category.Data, "ReadLogTesting");

            MSSQLLogGateway gateway = new MSSQLLogGateway(@"Data Source=.\SQLEXPRESS;Initial Catalog=logging;Integrated Security=True;Pooling=False");
            gateway.ReadLog(14823846);
        }


    }
}
