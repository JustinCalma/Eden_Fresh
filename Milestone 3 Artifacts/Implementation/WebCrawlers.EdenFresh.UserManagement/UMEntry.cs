using WebCrawlers.EdenFresh.Logging;

namespace WebCrawlers.EdenFresh.UserManagement
{
    class UMEntry
    {
        //Demo Class
        
        static void Main(String[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=logging;Integrated Security=True;Pooling=False";
            MSSQLUMGateway userGateway = new MSSQLUMGateway(connectionString);
            MSSQLLogGateway logGateway = new MSSQLLogGateway(connectionString);
            Authentication authN = new Authentication();
            Authorization authZ = new Authorization(authN);
            // chose an ID that exists in the testing database
            int inititatingUser = 430435;
            UMService serv = new UMService(userGateway);
            LogWriter logger = new LogWriter(logGateway);

            UMManager manager = new UMManager(inititatingUser, serv, authZ, logger);
            manager.CreateAccount("ReidarDaithi@gmail.com", "password", true);
            manager.CreateAccount("NacyKasey@yahoo.com", "123456", true);
            manager.CreateAccount("LexineArden@gmail.com", "randomPass1", true);
            manager.CreateAccount("GeirFederica@hotmail.com", "random", true);
            manager.CreateAccount("MilenaRosabel@gmail.com", "ran", true);
            manager.CreateAccount("GobnetSapphire@gmail.com", "pass", true);
            manager.CreateAccount("BobTheBuilder@yahoo.com", "thisPassword", true);
            manager.CreateAccount("NatureCat@gmail.com", "thatPassword", true);
            manager.CreateAccount("CuroiousGeorge@gmail.com", "theOtherPassword", true);
            manager.CreateAccount("ReadyJetGo@gmail.com", "morePassword", true);
            manager.CreateAccount("CliffordTheBigRedDog@gmail.com", "testPassword", true);

        }

        static void tester()
        {
            Random rnd = new Random();
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=logging;Integrated Security=True;Pooling=False";
            MSSQLUMGateway userGateway = new MSSQLUMGateway(connectionString);
            MSSQLLogGateway logGateway = new MSSQLLogGateway(connectionString);
            Authentication authN = new Authentication();
            Authorization authZ = new Authorization(authN);
            // chose an ID that exists in the testing database
            int inititatingUser = 430435;
            UMService serv = new UMService(userGateway);
            LogWriter logger = new LogWriter(logGateway);

            UMManager manager = new UMManager(inititatingUser, serv, authZ, logger);

            // create random accounts
            for (int i = 0; i < 20; i++)
            {
                manager.CreateAccount($"user{rnd.Next()}@email.com", $"password{rnd.Next()}", true);
            }


            // delete an account
            manager.DeleteAccount(593436, "email", "password");

            // update an account
            manager.UpdateAccount(506254, "email", "differentpassword", false);

            // disable some accounts
            manager.DisableAccount(506254, "email", "differentpassword");

            manager.DisableAccount(267842, "email", "password");

            Console.WriteLine("Please observe the disabled accounts.");
            Console.ReadKey();

            // enable a disabled account
            manager.EnableAccount(267842, "email", "password");
        }
    }
}