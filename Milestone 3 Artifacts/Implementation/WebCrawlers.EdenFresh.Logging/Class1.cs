using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlers.EdenFresh.Logging
{
    class LoggingDemo
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=logging;Integrated Security=True;Pooling=False";
            ILogGateway gateway = new MSSQLLogGateway(connectionString);
            LogWriter service = new LogWriter(gateway);
        }
    }
}
