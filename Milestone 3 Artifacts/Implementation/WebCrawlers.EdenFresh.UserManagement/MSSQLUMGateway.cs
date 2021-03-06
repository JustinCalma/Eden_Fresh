
using System.Data.SqlClient;

namespace WebCrawlers.EdenFresh.UserManagement
{
    class MSSQLUMGateway : IUserGateway
    {
        private string connectionString;
        private Random rnd = new Random();

        public MSSQLUMGateway(string connection)
        {
            this.connectionString = connection;
        }
        public Boolean WriteToDataStore(int userId, string email, string password, bool isEnabled)
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

        public Boolean DeleteFromDataStore(int userId, string email, string password)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                string query = "DELETE FROM Account WHERE UserId = @userId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", userId);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Account Log Records Deleted Successfully");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Cannot find data");
                        return true;
                    }

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

        public bool UpdateDataStore(int userId, string email, string password, bool isEnabled)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                string query = "UPDATE ACCOUNT SET Email = @email, Password = @password, IsEnabled = @isEnabled WHERE userId = @userId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@isEnabled", isEnabled);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("User Records Updated Successfully");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Unable to find user to update data");
                        return true;
                    }
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
                Console.WriteLine("UserRepo class Error:" + ex.Message);
                return false;
            }
        }

    }
}

