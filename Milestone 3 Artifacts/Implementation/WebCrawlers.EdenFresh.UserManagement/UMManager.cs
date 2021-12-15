using System.Diagnostics;
using WebCrawlers.EdenFresh.Logging;

namespace WebCrawlers.EdenFresh.UserManagement
{
    internal class UMManager
    {
        private Stopwatch stopwatch;
        private UMService umService;
        private int userId;
        private Authorization authorization;
        ILogGateway dao;
        LogWriter writer;
        Random rnd;

        public UMManager(int userID, UMService uMService, Authorization auth, LogWriter logging)
        {
            this.stopwatch = new Stopwatch();
            this.umService = uMService;
            this.userId = userID;
            this.authorization = auth;
            this.writer = logging;
            this.rnd = new Random();
        }

        public Boolean CreateAccount(String email, String password, Boolean isEnabled)
        {
            
            if (!this.authorization.AuthorizeUser(this.userId))
            {
                writer.Write(this.userId, LogWriter.LogLevel.Error, LogWriter.Category.Business, $"User {this.userId} Is Unauthorized to Create Account");
                return false;
            }
            
            try
            {
                stopwatch.Restart();
                stopwatch.Start();
                int newID = this.rnd.Next(100000, 999999);
                bool operationSuccessful = umService.CreateAccount(newID, email, password, isEnabled);
                stopwatch.Stop();
                writer.Write(this.userId, LogWriter.LogLevel.Info, LogWriter.Category.DataStore, $"User {this.userId} Created New User Account With ID {newID}");
                return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
            }
            catch (Exception ex)
            {
                writer.Write(this.userId, LogWriter.LogLevel.Error, LogWriter.Category.DataStore, $"User {this.userId} had an Error In Creating New User Account");
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public Boolean DeleteAccount(int userId, String email, String password)
        {
            if (!this.authorization.AuthorizeUser(this.userId))
            {
                writer.Write(this.userId, LogWriter.LogLevel.Error, LogWriter.Category.Business, $"User {this.userId} Is Unauthorized to Delete Account");
                return false;
            }
            try
            {
                stopwatch.Restart();
                stopwatch.Start();
                bool operationSuccessful = umService.DeleteAccount(userId, email, password);
                stopwatch.Stop();
                writer.Write(this.userId, LogWriter.LogLevel.Info, LogWriter.Category.DataStore, $"User {this.userId} Deleted User Account with ID {userId}");
                return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
            }
            catch(Exception ex)
            {
                writer.Write(this.userId, LogWriter.LogLevel.Error, LogWriter.Category.DataStore, $"User {this.userId} had an Error In Deleting User Account");
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public Boolean UpdateAccount(int userId, String email, String password, Boolean isEnabled)
        {
            if (!this.authorization.AuthorizeUser(this.userId))
            {
                writer.Write(this.userId, LogWriter.LogLevel.Error, LogWriter.Category.Business, $"User {this.userId} Is Unauthorized to Update Account");
                return false;
            }
            try
            {
                stopwatch.Restart();
                stopwatch.Start();
                bool operationSuccessful = umService.UpdateAccount(userId, email, password, isEnabled);
                stopwatch.Stop();
                writer.Write(this.userId, LogWriter.LogLevel.Info, LogWriter.Category.Data, $"User {this.userId} Updated User Account with ID {userId}");
                return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
            }
            catch (Exception ex)
            {
                writer.Write(this.userId, LogWriter.LogLevel.Error, LogWriter.Category.Data, $"User {this.userId} had an Error In Updating User Account");
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public Boolean EnableAccount(int userId, String email, String password)
        {
            if (!this.authorization.AuthorizeUser(this.userId))
            {
                writer.Write(this.userId, LogWriter.LogLevel.Error, LogWriter.Category.Business, $"User {this.userId} Is Unauthorized to Enable Account");
                return false;
            }
            try
            {
                stopwatch.Restart();
                stopwatch.Start();
                bool operationSuccessful = umService.UpdateAccount(userId, email, password, true);
                stopwatch.Stop();
                writer.Write(userId, LogWriter.LogLevel.Info, LogWriter.Category.Data, $"User {this.userId} Enabled User Account with ID {userId}");
                return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
            }
            catch(Exception ex)
            {
                writer.Write(this.userId, LogWriter.LogLevel.Error, LogWriter.Category.Data, $"User {this.userId} had an Error In Enabling User Account");
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public Boolean DisableAccount(int userId, String email, String password)
        {
            if (!this.authorization.AuthorizeUser(this.userId))
            {
                writer.Write(this.userId, LogWriter.LogLevel.Error, LogWriter.Category.Business, $"User {this.userId} Is Unauthorized to Disable Account");
                return false;
            }
            try
            {
                stopwatch.Restart();
                stopwatch.Start();
                bool operationSuccessful = umService.UpdateAccount(userId, email, password, false);
                stopwatch.Stop();
                writer.Write(userId, LogWriter.LogLevel.Info, LogWriter.Category.Data, $"User {this.userId} Disabled User Account with ID {userId}");
                return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
            }
            catch(Exception ex)
            {
                writer.Write(this.userId, LogWriter.LogLevel.Error, LogWriter.Category.Data, $"User {this.userId} had an Error In Disabling User Account");
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
