
using System.Diagnostics;


namespace WebCrawlers.EdenFresh.UserManagement
{
    internal class UMManager
    {
        private Stopwatch stopwatch;
        private UMService umService = new UMService();
        public UMManager()
        {
            this.stopwatch = new Stopwatch();
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
