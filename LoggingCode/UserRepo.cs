using System;
using System.Data.SqlClient;

namespace EdenFresh
{
    // data access layer
    class UserRepo : IUserDAO
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=logging;Integrated Security=True;Pooling=False";
        private LogWriter logWriter;
        public void createUser(User user)
        {

            Random rnd = new Random();
            int value = rnd.Next(100000, 999999); // 6 digit generator

            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                string query = "INSERT INTO Users (UserId, FirstName, LastName, Username, Password, Email) VALUES (@id, @firstN, @lastN, @userN, @pass, @email)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", user.userId);
                cmd.Parameters.AddWithValue("@firstN", user.firstName);
                cmd.Parameters.AddWithValue("@lastN", user.lastName);
                cmd.Parameters.AddWithValue("@userN", user.username);
                cmd.Parameters.AddWithValue("@pass", user.password);
                cmd.Parameters.AddWithValue("@email", user.email);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Records Inserted Successfully: User");
                    logWriter = new LogWriter(user.userId, 3, DateTime.Now, "CREATE", "INSERT NEW USER INTO RECORDS SUCCESSFULLY");
                    logWriter.write();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        Console.WriteLine("Duplicate Key...reassigning key");
                        user.userId = value;
                        logWriter = new LogWriter(user.userId, 6, DateTime.Now, "SQLEXCEPTION", "Reassigning userId key");
                        logWriter.write();
                        createUser(user);
                    }
                    else
                    {
                        Console.WriteLine(ex.ToString());
                        logWriter = new LogWriter(user.userId, 0, DateTime.Now, "SQLEXCEPTION", ex.Message);
                        logWriter.write();
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
                logWriter = new LogWriter(user.userId,1, DateTime.Now, "SQLEXCEPTION", ex.Message);
                logWriter.write();
            }
        }

     
        public void deleteUser(int userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                string query = "DELETE FROM Users WHERE UserId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", userId);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Records Deleted Successfully: User");
                    logWriter = new LogWriter(userId,2, DateTime.Now, "DELETE", "DELETE USER FROM RECORDS SUCCESSFULLY");
                    logWriter.write();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
                    logWriter = new LogWriter(userId,0, DateTime.Now, "SQLEXCEPTION", ex.Message);
                    logWriter.write();
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
                logWriter = new LogWriter(userId, 1, DateTime.Now, "EXCEPTION", ex.Message);
                logWriter.write();
            }
        }

        public void getAllUsers()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
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
                    Console.WriteLine("All Records read Successfully");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error: " + e.ToString());

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

        public void readUser(int userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                string query = "Select * from Users where UserId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", userId);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() );
                    }
                    Console.WriteLine("Records read Successfully");
                    logWriter = new LogWriter(userId,4, DateTime.Now, "READ", "READ FROM RECORDS SUCCESSFULLY");
                    logWriter.write();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
                    logWriter = new LogWriter(userId,0, DateTime.Now, "SQLEXCEPTION", ex.Message);
                    logWriter.write();
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
                logWriter = new LogWriter(userId, 1, DateTime.Now, "EXCEPTION", ex.Message);
                logWriter.write();
            }
        }

        public void updateUser(User user)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);

                string query = "UPDATE Users SET FirstName = @firstN, LastName = @lastN, Username = @userN, password = @pass, email = @email WHERE UserId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", user.userId);
                cmd.Parameters.AddWithValue("@firstN", user.firstName);
                cmd.Parameters.AddWithValue("@lastN", user.lastName);
                cmd.Parameters.AddWithValue("@userN", user.username);
                cmd.Parameters.AddWithValue("@pass", user.password);
                cmd.Parameters.AddWithValue("@email", user.email);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Records Updated Successfully");
                    logWriter = new LogWriter(user.userId, 5, DateTime.Now, "UPDATE", "UPDATE USER SUCCESSFULLY");
                    logWriter.write();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
                    logWriter = new LogWriter(user.userId, 0, DateTime.Now, "SQLEXCEPTION", ex.Message);
                    logWriter.write();
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
                logWriter = new LogWriter(user.userId, 1, DateTime.Now, "EXCEPTION", ex.Message);
                logWriter.write();
            }
        }

    }
    
}
