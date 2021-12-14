using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlers.EdenFresh.Logging
{
    class MSSQLLogGateway : ILogGateway
    {
        private string connectionString;

        public MSSQLLogGateway(string connection)
        {
            this.connectionString = connection;
        }
        public bool DeleteLogsWhere(string columnName, Comparator compare, string value)
        {
            throw new NotImplementedException();
        }

        public DataTable ReadLogsWhere(string columnName, Comparator compare, string value)
        {
            using(SqlConnection conn = new SqlConnection(this.connectionString))
            {

            }
        }

        public bool WriteLog(int userId, DateTime timeStamp, LogLevel logLevel, Category category, string message)
        {
            throw new NotImplementedException();
        }
    }
}
