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
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                string query = "SELECT * FROM Logger WHERE ";
                switch (compare)
                {
                    case Comparator.LESS:
                        query += "< @value";
                        break;
                    case Comparator.GREATER:
                        query += "> @value";
                        break;
                    case Comparator.EQUAL:
                        query += "= @value";
                        break;
                    case Comparator.NOT:
                        query += "<> @value";
                        break;
                }
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@value", value);
                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                return table;
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return new DataTable ();
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        public bool WriteLog(int userId, DateTime timeStamp, LogLevel logLevel, Category category, string message)
        {
            throw new NotImplementedException();
        }
    }
}
