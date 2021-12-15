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
            bool cont = true;

            while(cont)
            {
                Console.WriteLine("Please select an action by inputing a number");
                Console.WriteLine("1) Create Account");
                Console.WriteLine("2) Enable Account");
                Console.WriteLine("3) Disable Account");
                Console.WriteLine("4) Update Account");
                Console.WriteLine("5) Delete Account");
                String selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        Console.WriteLine("Please input Email");
                        String email0 = Console.ReadLine();
                        Console.WriteLine("Please input password");
                        String pass0 = Console.ReadLine();
                        manager.CreateAccount(email0, pass0, true);
                        break;
                    case "2":
                        Console.WriteLine("Please input UserId");
                        string userId1 = Console.ReadLine();
                        Console.WriteLine("Please input Email");
                        String email1 = Console.ReadLine();
                        Console.WriteLine("Please input password");
                        String pass1 = Console.ReadLine();
                        manager.EnableAccount((int) userId1, email1, pass1, true);
                        break;
                    case "3":
                        Console.WriteLine("Please input UserId");
                        string userId2 = Console.ReadLine();
                        Console.WriteLine("Please input Email");
                        String email2 = Console.ReadLine();
                        Console.WriteLine("Please input password");
                        String pass2 = Console.ReadLine();
                        manager.DisableAccount((int)userId2, email2, pass2, false);
                        break;
                    case "4":
                        Console.WriteLine("Please input UserId");
                        string userId3 = Console.ReadLine();
                        Console.WriteLine("Please input Email");
                        String email3 = Console.ReadLine();
                        Console.WriteLine("Please input password");
                        String pass3 = Console.ReadLine();
                        Console.WriteLine("Is Account going to be enabled?(true/false)");
                        String enable3 = Console.ReadLine();
                        manager.UpdateAccount((int)userId3, email3, pass3, Convert.ToBoolean(enable3));
                        break;
                    case "5":
                        Console.WriteLine("Please input UserId");
                        string userId4 = Console.ReadLine();
                        Console.WriteLine("Please input Email");
                        String email4 = Console.ReadLine();
                        Console.WriteLine("Please input password");
                        String pass4 = Console.ReadLine();
                        Console.WriteLine("Is Account going to be enabled?(true/false)");
                        String enable4 = Console.ReadLine();
                        manager.DeleteAccount((int)userId4, email4, pass4);
                        break;
                    default:
                        Console.WriteLine("Invalid Number");
                        break;
                }
                Console.WriteLine("Do you want to select another (Y\N)");
                switch (Console.ReadLine())
                {
                    case "Y":
                        break;
                    case "y":
                        break;
                    case "N":
                        Console.WriteLine("Have a nice day :)");
                        cont = false;
                        break;
                    case "n":
                        Console.WriteLine("Have a nice day :)");
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("Have a nice day :)");
                        cont = false;
                        break;
                }
            }




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