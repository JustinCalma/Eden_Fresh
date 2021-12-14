using System.Data.SqlClient;

namespace EdenFreshApplication
{
    class MSSQLLogGateway:ILogGateway
    {
        private Random rnd = new Random();
        private int logId;
        /*
         * constructor
         */
        public MSSQLLogGateway() { }
        
        /*
         * writes to the logging table
         * if any of the parameters are
         */
        public Boolean Write(int userId, DateTime timeStamp, LogWriter.LogLevel logLevel, LogWriter.Category category, string message)
        {
            
            int value = rnd.Next(100000, 999999);
            try
            {
                SqlConnection con = new SqlConnection(connection.getConnectionString());
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
                        Write(userId, timeStamp, logLevel, category,message);
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

        //Read logged action/error of a single user
        public Boolean ReadLog(int logId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection.getConnectionString());
                string query = "Select * from Logger where UserId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", logId);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() + " " + reader[5].ToString());
                    }
                    Console.WriteLine("Logger Records read Successfully");
                    return true;
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
      
        public Boolean UpdateLog(int logId, LogWriter replacementLog)
        {
            try
            {

                SqlConnection con = new SqlConnection(connection.getConnectionString());
                string query = "UPDATE Logger SET UserId = @userId, DateTime = @dateTime, loglevel = @logLevel, category = @category, message = @message WHERE LogId = @logId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@logId", logId);
                cmd.Parameters.AddWithValue("@userId", replacementLog.userId);
                cmd.Parameters.AddWithValue("@dateTime", replacementLog.timeStamp);
                cmd.Parameters.AddWithValue("@logLevel", replacementLog.logLevel);
                cmd.Parameters.AddWithValue("@Category", replacementLog.category);
                cmd.Parameters.AddWithValue("@Message", replacementLog.message);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Log Records Updated Successfully");
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

        //not too sure if we need delete functions
        public Boolean DeleteLog(int logId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection.getConnectionString());

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

        /*
        //delete from log using logId
        public void deleteLogEntry(int userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection.getConnectionString());

                string query = "DELETE FROM logger WHERE logId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", logId);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Log Records Deleted Successfully");

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
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
            }
        }
        */
        /*
        public void readLogEventId(int eventId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection.getConnectionString());
                string query = "Select * from Logger where eventTypeId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", eventId);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() + " " + reader[5].ToString());
                    }
                    Console.WriteLine("Logger Records read Successfully");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
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

            }
        }
        */
    }
}
