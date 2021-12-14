
using System.Data.SqlClient;

namespace WebCrawlers.EdenFresh.UserManagement
{
    class MSSQLUMGateway : IUserGateway
    {
        private string connectionString;
        private int userId;
        private Random rnd = new Random();

        public MSSQLUMGateway(string connection)
        {
            this.connectionString = connection;
            userId = rnd.Next(100000, 999999);
        }
        public Boolean WriteToDataStore(string username, string email, string password, bool isEnabled)
        {
            int value = rnd.Next(100000, 999999);
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                string query = "INSERT INTO ACCOUNT(UserId, Username, Password, Email, IsEnabled) VALUES (@userId, @username, @password, @email, @isEnabled)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@isEnabled", isEnabled);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Account: Log Records Inserted Successfully");
                    return true;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)//SQL Duplicate primary key exception 
                    {
                        Console.WriteLine("Duplicate Key...reassigning key");
                        userId = value;
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

        public bool DeleteFromDataStore(string userID, string email, string password, bool isEnabled)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDataStore(string userID, string email, string password, bool isEnabled)
        {
            throw new NotImplementedException();
        }
    }
}
