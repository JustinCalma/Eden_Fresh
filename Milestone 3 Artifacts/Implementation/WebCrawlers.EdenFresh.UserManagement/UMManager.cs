using System.Diagnostics;
using WebCrawlers.EdenFresh.Logging;

namespace WebCrawlers.EdenFresh.UserManagement
{
    internal class UMManager
    {
        private Stopwatch stopwatch;
        private UMService umService;
        private Random rnd = new Random();
        private int userId; 

        ILogGateway dao;
        LogWriter writer;
        public UMManager(String connectionString)
        {
            this.stopwatch = new Stopwatch();
            umService = new UMService(connectionString);
            dao = new MSSQLLogGateway(connectionString);
            writer = new LogWriter(dao);
            userId = rnd.Next(100000, 999999);
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
