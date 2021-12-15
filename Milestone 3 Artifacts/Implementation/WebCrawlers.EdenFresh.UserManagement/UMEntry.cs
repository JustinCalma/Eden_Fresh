namespace WebCrawlers.EdenFresh.UserManagement
{
    class UMEntry
    {
        //Demo Class
        
          static void Main(String[] args)
          {
                string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=logging;Integrated Security=True;Pooling=False";
                MSSQLUMGateway gateway = new MSSQLUMGateway(connectionString);
                //gateway.WriteToDataStore("email", "password", true);
                gateway.DeleteFromDataStore(729527, "gmail", "password", true);

           }
        


    }
}