using System.Data.SqlClient;


namespace EdenFreshApplication
{
    // data access layer
    class UserRepo : IUserDAO
    {
        private LogWriter logWriter;

        /*
         * creates the user and inserts the user's data into the User's table. If any of the parameters are null/missing, the user will not be able to create an account
         * if the user has the same email address as another active account, the system will not create the account
         * userId is set between 100,000 and 999,999 and is randomly generated 
         */
        public void createUser(User user)
        {

            Random rnd = new Random();
            int value = rnd.Next(100000, 999999); // 6 digit generator

            try
            {
                SqlConnection con = new SqlConnection(connection.getConnectionString());
                string query = "INSERT INTO Users (UserId, FirstName, LastName, Password, Email, Address, City, State, Zipcode) VALUES (@id, @firstN, @lastN, @pass, @email, @address, @city, @state, @zipcode)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", user.userId);
                cmd.Parameters.AddWithValue("@firstN", user.firstName);
                cmd.Parameters.AddWithValue("@lastN", user.lastName);
                cmd.Parameters.AddWithValue("@pass", user.password);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@address", user.address);
                cmd.Parameters.AddWithValue("@city", user.city);
                cmd.Parameters.AddWithValue("@state", user.state);
                cmd.Parameters.AddWithValue("@zipcode", user.zipcode);


                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Records Inserted Successfully: User");
                    logWriter = new LogWriter(user.userId, DateTime.Now, LogWriter.LogLevel.Info, LogWriter.Category.DataStore, "INSERT NEW USER INTO RECORDS SUCCESSFULLY");
                    logWriter.Write();
                }
                catch (SqlException ex)
                {
                    
                    //primary key exception
                    if (ex.Number == 2627)
                    {
                        Console.WriteLine("Duplicate Primary Key...reassigning key");
                        user.userId = value;
                        logWriter = new LogWriter(user.userId, DateTime.Now, LogWriter.LogLevel.Error, LogWriter.Category.DataStore, "Reassigning userId key");
                        logWriter.Write();
                        createUser(user);
                    }
                    else
                    {
                        Console.WriteLine("UserRepo class Error:" + ex.ToString());
                        logWriter = new LogWriter(user.userId, DateTime.Now, LogWriter.LogLevel.Error, LogWriter.Category.DataStore, ex.Message);
                        logWriter.Write();
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
                Console.WriteLine(ex.Message);
                logWriter = new LogWriter(user.userId, DateTime.Now, LogWriter.LogLevel.Error, LogWriter.Category.DataStore, ex.Message);
                logWriter.Write();
            }
        }

        /*
         * called to delete a user and the user data from the User table
         */
        public void deleteUser(int userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection.getConnectionString());

                string query = "DELETE FROM Users WHERE UserId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", userId);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Records Deleted Successfully: User");
                    logWriter = new LogWriter(userId, DateTime.Now, LogWriter.LogLevel.Info, LogWriter.Category.DataStore, "DELETE USER FROM RECORDS SUCCESSFULLY");
                    logWriter.Write();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("UserRepo class Error: " + ex.ToString());
                    logWriter = new LogWriter(userId, DateTime.Now, LogWriter.LogLevel.Error, LogWriter.Category.DataStore, ex.Message);
                    logWriter.Write();
                }
                finally
                {
                    con.Close();
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UserRepo class Error: " + ex.Message);
                logWriter = new LogWriter(userId, DateTime.Now, LogWriter.LogLevel.Error, LogWriter.Category.DataStore, ex.Message);
                logWriter.Write();
            }
        }

        /*
         * reads all the user's data
         */
        public void getAllUsers()
        {
            try
            {
                SqlConnection con = new SqlConnection(connection.getConnectionString());
                string query = "Select * from Users ";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
                    }
                    Console.WriteLine("All user Records read Successfully");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UserRepo class Error: " + e.ToString());

                }
                finally
                {
                    con.Close();
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UserRepo class Error: " + ex.Message);
            }
        }

        /*
         * reads the data of a single user
         */
        public void readUser(int userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection.getConnectionString());
                string query = "Select * from Users where UserId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", userId);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString());
                    }
                    Console.WriteLine("User Records read Successfully");
                    logWriter = new LogWriter(userId, DateTime.Now, LogWriter.LogLevel.Info, LogWriter.Category.View, "READ FROM RECORDS SUCCESSFULLY");
                    logWriter.Write();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("UserRepo class Error: " + ex.ToString());
                    logWriter = new LogWriter(userId, DateTime.Now, LogWriter.LogLevel.Error, LogWriter.Category.View, ex.Message);
                    logWriter.Write();
                }
                finally
                {
                    con.Close();
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UserRepo class Error: " + ex.Message);
                logWriter = new LogWriter(userId, DateTime.Now, LogWriter.LogLevel.Error, LogWriter.Category.View, ex.Message);
                logWriter.Write();
            }
        }

        /*
         * updates the users account
         */
        public void updateUser(User user)
        {
            try
            {

                SqlConnection con = new SqlConnection(connection.getConnectionString());

                string query = "UPDATE Users SET FirstName = @firstN, LastName = @lastN, Password = @pass, Email = @email, Address = @address, City = @city, State = @state, Zipcode = @zipcode WHERE UserId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", user.userId);
                cmd.Parameters.AddWithValue("@firstN", user.firstName);
                cmd.Parameters.AddWithValue("@lastN", user.lastName);
                cmd.Parameters.AddWithValue("@pass", user.password);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@address", user.address);
                cmd.Parameters.AddWithValue("@city", user.city);
                cmd.Parameters.AddWithValue("@state", user.state);
                cmd.Parameters.AddWithValue("@zipcode", user.zipcode);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("User Records Updated Successfully");
                    logWriter = new LogWriter(user.userId, DateTime.Now, LogWriter.LogLevel.Info, LogWriter.Category.DataStore, "UPDATE USER SUCCESSFULLY");
                    logWriter.Write();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("UserRepo class Error: " + ex.ToString());
                    logWriter = new LogWriter(user.userId, DateTime.Now, LogWriter.LogLevel.Error, LogWriter.Category.DataStore, ex.Message);
                    logWriter.Write();
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
                logWriter = new LogWriter(user.userId, DateTime.Now, LogWriter.LogLevel.Error, LogWriter.Category.DataStore, ex.Message);
                logWriter.Write();
            }
        }

    }

}
