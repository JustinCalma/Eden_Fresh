
using System.Data;
using System.Data.SqlClient;


namespace WebCrawlers.EdenFresh.Logging
{
    public class MSSQLLogGateway : ILogGateway
    {
        private string connectionString;
        private int logId;
        private Random rnd = new Random();

        public MSSQLLogGateway(string connection)
        {
            this.connectionString = connection;
            logId = rnd.Next();
        }
        public int DeleteLogsWhere(string columnName, Comparator compare, string value)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                string query = "DELETE * FROM Logger WHERE ";
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
                int deletedRows = command.ExecuteNonQuery();
                return deletedRows;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        public DataTable ReadLogsWhere(string columnName, Comparator compare, string value)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                string query = $"SELECT * FROM Logger WHERE {columnName}";
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
                Console.WriteLine(command.CommandText);
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

        public Boolean WriteLog(int userId, DateTime timeStamp, LogWriter.LogLevel logLevel, LogWriter.Category category, string message)
        {

            int value = rnd.Next(100000, 999999);
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                string query = "INSERT INTO LOGGER (LogId, UserId, TimeDate, LogLevel, Category, Message) VALUES (@logId, @userId, @timeDate, @logLevel, @category, @message)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@logId", logId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@timeDate", timeStamp);
                cmd.Parameters.AddWithValue("@logLevel", logLevel);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@message", message);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Log Records Inserted Successfully");
                    return true;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)//SQL Duplicate primary key exception 
                    {
                        Console.WriteLine("Duplicate Key...reassigning key");
                        logId = value;
                        WriteLog(userId, timeStamp, logLevel, category, message);
                        return false;
                    }
                }
                finally
                {
                    con.Close();
                    Console.ReadKey();

                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;

            }
        }
    }
}

