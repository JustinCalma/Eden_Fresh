namespace WebCrawlers.EdenFresh.UserManagement
{
    class UMEntry
    {
        //Demo Class
        
          static void Main(String[] args)
          {
                string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=logging;Integrated Security=True;Pooling=False";
                UMManager manager = new UMManager(connectionString);
                manager.CreateAccount("username", "gmail", "password", true);


           }
        


    }
}