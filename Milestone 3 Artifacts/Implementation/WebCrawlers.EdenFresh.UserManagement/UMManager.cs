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
        public UMManager(int userID, UMService uMService, Authorization auth)
        {
            this.stopwatch = new Stopwatch();
            this.umService = uMService;
            this.userId = userID;
            this.authorization = auth;
        }

        public Boolean CreateAccount(String email, String password, Boolean isEnabled)
        {
            try
            {
                stopwatch.Restart();
                stopwatch.Start();
                bool operationSuccessful = umService.CreateAccount(userId, email, password, isEnabled);
                stopwatch.Stop();
                writer.Write(userId, LogWriter.LogLevel.Info, LogWriter.Category.DataStore, "Creating New User Account");
                return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
            }
            catch (Exception ex)
            {
                writer.Write(userId, LogWriter.LogLevel.Error, LogWriter.Category.DataStore, "Error In Creating New User Account");
                return false;
            }
        }
        public Boolean DeleteAccount(int userId, String email, String password, Boolean isEnabled)
        {
            try
            {
                stopwatch.Restart();
                stopwatch.Start();
                bool operationSuccessful = umService.DeleteAccount(userId, email, password, isEnabled);
                stopwatch.Stop();
                return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Boolean UpdateAccount(int userId, String email, String password, Boolean isEnabled)
        {
            stopwatch.Restart();
            stopwatch.Start();
            bool operationSuccessful = umService.UpdateAccount(userId, email, password, isEnabled);
            stopwatch.Stop();
            return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
        }

        public Boolean EnableAccount(int userId, String email, String password)
        {
            stopwatch.Restart();
            stopwatch.Start();
            bool operationSuccessful = umService.UpdateAccount(userId, email, password, true);
            stopwatch.Stop();
            return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
        }

        public Boolean DisableAccount(int userId, String email, String password)
        {
            stopwatch.Restart();
            stopwatch.Start();
            bool operationSuccessful = umService.UpdateAccount(userId, email, password, false);
            stopwatch.Stop();
            return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
        }
    }
}
