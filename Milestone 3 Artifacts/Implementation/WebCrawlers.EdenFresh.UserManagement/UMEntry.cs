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


                Console.WriteLine("Please select an action by inputing a number");
                Console.WriteLine("1) Create Account w/ USERNAME: ThisAccountForTesting@gmail.com PASSWORD: thisPasswordForTesting");
                Console.WriteLine("2) Enable Account w/ USERID:576148 USERNAME: GeirFederica@hotmail.com PASSWORD: random");
                Console.WriteLine("3) Disable Account w/ USERID:670336 USERNAME: NacyKasey@yahoo.com PASSWORD: updatedPassword");
                Console.WriteLine("4) Update Account w/ USERID:612184 USERNAME:MilenaRosabel@gmail.com PASSWORD: theOtherUpdatedPassword ");
                Console.WriteLine("5) Delete Account w/ USERID:187384 USERNAME: LexineArden@gmail.com PASSWORD: randomPass1");
                String selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        manager.CreateAccount("ThisAccountForTesting@gmail.com", "thisPasswordForTesting", true);
                        break;
                    case "2":
                        manager.EnableAccount(576148, "GeirFederica@hotmail.com", "random"  );
                        break;
                    case "3":
                        manager.DisableAccount(670336, "NacyKasey@yahoo.com", "updatedPassword");
                        break;
                    case "4":
                        manager.UpdateAccount(612184, "MilenaRosabel@gmail.com", "theOtherUpdatedPassword", true);
                        break;
                    case "5":
                        manager.DeleteAccount(187384, "LexineArden@gmail.com", "randomPass1");
                        break;
                    default:
                        Console.WriteLine("Invalid Number");
                        break;
                }
                Console.WriteLine("Have a nice day :)");
           




            /*
            //CreateAccounts
            manager.CreateAccount("ThisAccountForTesting@gmail.com", "thisPasswordForTesting", true);
            manager.CreateAccount("ThatAccountForTesting@yahoo.com", "thatPasswordForTesting", true);
            manager.CreateAccount("TheOtherAccountForTesting@gmail.com", "theOtherPasswordForTesting", true);

            //DisableAccounts
            manager.DisableAccount(187384, "LexineArden@gmail.com", "randomPass1");
            manager.DisableAccount(670336, "NacyKasey@yahoo.com", "updatedPassword");

            //UpdateAccounts
            manager.UpdateAccount(612184, "MilenaRosabel@gmail.com", "theOtherUpdatedPassword", true);
            //

            //Enable Accounts
            manager.EnableAccount(187384, "LexineArden@gmail.com", "randomPass1");

            //DeleteAccounts
            manager.DeleteAccount(187384, "LexineArden@gmail.com", "randomPass1");
           */




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

        /*
        static void createUserTester()
        {
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
        */
    }
}