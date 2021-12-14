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

        public Boolean CreateAccount(String userName, String email, String password, Boolean isEnabled)
        {
            stopwatch.Restart();
            stopwatch.Start();
            bool operationSuccessful = umService.CreateAccount(userName, email, password,isEnabled);
            stopwatch.Stop();
            return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
        }
    }
}
