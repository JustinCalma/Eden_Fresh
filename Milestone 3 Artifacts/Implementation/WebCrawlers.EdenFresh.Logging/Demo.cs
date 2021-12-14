
namespace WebCrawlers.EdenFresh.Logging
{
    class Demo
    {
        
        static void Main(string[] args)
        {

            MSSQLLogGateway gateway = new MSSQLLogGateway(@"Data Source=.\SQLEXPRESS;Initial Catalog=logging;Integrated Security=True;Pooling=False");
            Console.WriteLine(gateway.WriteLog(0, DateTime.Now, LogWriter.LogLevel.Info, LogWriter.Category.Data, "Testing"));
        }


    }
}
