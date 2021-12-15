
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
        public Boolean WriteToDataStore(string email, string password, bool isEnabled)
        {
            int value = rnd.Next(100000, 999999);
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                string query = "INSERT INTO ACCOUNT(UserId, Password, Email, IsEnabled) VALUES (@userId, @password, @email, @isEnabled)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", userId);
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

        public Boolean DeleteFromDataStore(int userID, string email, string password, bool isEnabled)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                string query = "DELETE FROM ACCOUNT WHERE UserId = @userId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", userId);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Account Log Records Deleted Successfully");
                    return true;

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("MSSQLUMGateway class Error: " + ex.ToString());
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

        public bool UpdateDataStore(int userID, string email, string password, bool isEnabled)
        {
            throw new NotImplementedException();
        }
    }
}
