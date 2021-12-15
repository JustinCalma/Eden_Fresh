using System.Diagnostics;

namespace WebCrawlers.EdenFresh.UserManagement
{
    internal class UMManager
    {
        private Stopwatch stopwatch;
        private UMService umService;
        public UMManager(String connectionString)
        {
            this.stopwatch = new Stopwatch();
            umService = new UMService(connectionString);
        }

        public Boolean CreateAccount(String email, String password, Boolean isEnabled)
        {
            stopwatch.Restart();
            stopwatch.Start();
            bool operationSuccessful = umService.CreateAccount(email, password,isEnabled);
            stopwatch.Stop();
            return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
        }
        public Boolean DeleteAccount(int userId, String email, String password, Boolean isEnabled)
        {
            stopwatch.Restart();
            stopwatch.Start();
            bool operationSuccessful = umService.DeleteAccount(userId, email, password, isEnabled);
            stopwatch.Stop();
            return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
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
