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

        public Boolean CreateAccount(String username, String email, String password, Boolean isEnabled)
        {
            stopwatch.Restart();
            stopwatch.Start();
            bool operationSuccessful = umService.CreateAccount(username, email, password,isEnabled);
            stopwatch.Stop();
            return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
        }
        public Boolean DeleteAccount(String username, String email, String password)
        {
            stopwatch.Restart();
            stopwatch.Start();
            bool operationSuccessful = umService.DeleteAccount(username, email, password);
            stopwatch.Stop();
            return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
        }
    }
}
