using System;

namespace EdenFresh
{
    class UserDemo
    {
        static void Main(String[] args)
        {
            UserRepo repo = new UserRepo();
            User testUser = new User("Kayla", "Chu", "email", "pass", "username");
            LogWriter writer = new LogWriter();
        }


    }
}
