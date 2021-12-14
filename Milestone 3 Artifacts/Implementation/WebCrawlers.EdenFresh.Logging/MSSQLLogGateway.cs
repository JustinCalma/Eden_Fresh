
using System.Data;
using System.Data.SqlClient;


namespace WebCrawlers.EdenFresh.Logging
{
    class MSSQLLogGateway : ILogGateway
    {
        private string connectionString;
        private int logId;
        private Random rnd = new Random();

        public MSSQLLogGateway(string connection)
        {
            this.connectionString = connection;
            logId = rnd.Next();
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
        public Boolean DeleteLog(int logId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                string query = "DELETE FROM logger WHERE logId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", logId);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Log Records Deleted Successfully");
                    return true;

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("MSSQLLogGateway class Error: " + ex.ToString());
                    return false;
                }
                finally
                {
                    con.Close();
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Boolean ReadLog(int logId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                string query = "Select * from Logger where LogId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", logId);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        Console.WriteLine("Not Reading");
                        return false;

                    }
                    else
                    {
                        do
                        {
                            Console.WriteLine("Reading?");
                            Console.WriteLine(logId + " " + reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() + " " + reader[5].ToString());
                        }
                        while (reader.Read());
                        Console.WriteLine("Logger Records read Successfully");
                        return true;
                    }
                    
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
                    return false;
                }
                finally
                {
                    con.Close();
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;

            }
        }

        
    }
}

