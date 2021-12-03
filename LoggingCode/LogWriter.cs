using System;
using System.Data.SqlClient;

namespace EdenFresh
{
    class LogWriter
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=logging;Integrated Security=True;Pooling=False";
        private int logId; 
        private int eventTypeId;
        private int userId;
        private DateTime timeStamp;
        private string catagory;
        private string description;
        private Random rnd; 
        public LogWriter ()
        {
            
        }
        public LogWriter(int userId, int evenTypeId, DateTime timeStamp, string category, string description)
        {
            rnd = new Random();
            int value = rnd.Next(100000, 999999);
            this.logId = value;
            this.userId = userId;
            this.eventTypeId = evenTypeId;
            this.timeStamp = timeStamp;
            this.catagory = category;
            this.description = description; 
        }

        //CRUD: CREATE READ UPDATE DELETE
        //Create message
        public void write()
        {
            rnd = new Random();
            int value = rnd.Next(100000, 999999);
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                string query = "INSERT INTO LOGGER (LogId, UserId, EventTypeId, EventTime, Category, Description) VALUES (@logId, @userId, @eventTypeId, @eventTime, @category, @description)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@logId", logId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@eventTypeId", eventTypeId);
                cmd.Parameters.AddWithValue("@eventTime", timeStamp);
                cmd.Parameters.AddWithValue("@category", catagory);
                cmd.Parameters.AddWithValue("@description", description);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery(); 
                    Console.WriteLine("Log Records Inserted Successfully");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)//SQL Duplicate primary key exception 
                    {
                        Console.WriteLine("Duplicate Key...reassigning key");
                       
                        logId = value;
                         write();
                    }
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

        //Read logged action/error of a single user
        public void readUserId(int userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                string query = "Select * from Logger where UserId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", userId);
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

        //read all logged event type 
        public void readEventTypeId(int eventId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                string query = "Select * from Logger where eventTypeId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", eventId);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() + " " +reader[5].ToString());
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

        public void deleteUserLogEntry(int userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                string query = "DELETE FROM logger WHERE UserId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", userId);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("User Log Records Deleted Successfully");

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

        public void deleteLogEntry(int logId)
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
        
        //UPDATE LOG DOES NOT WORK 
        public void updateLog()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                string query = "UPDATE Users SET LogId = @logId, UserId = @userId, EventTypeId = @eventTypeId, EventTime = @eventTime, Category = @category, Description = @description";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@logId", logId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@eventTypeId", eventTypeId);
                cmd.Parameters.AddWithValue("@eventTime", timeStamp);
                cmd.Parameters.AddWithValue("@category", catagory);
                cmd.Parameters.AddWithValue("@description", description);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Log Records Updated Successfully");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message); 
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

    }
}
