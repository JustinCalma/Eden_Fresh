

namespace EdenFreshApplication
{
    class UserDemo
    {
        static void Main(String[] args)
        {
            UserRepo repo = new UserRepo();
            createUser(repo);


        }
        static void createUser(UserRepo repo)
        {
            User testUser0 = new User("Bob", "the builder", "email0@gmail.com", "password0", "123 random street", "long beach", "CA", 95682);
            User testUser1 = new User("Austin", "White", "email1@gmail.com", "password1", "1234 coast street", "long beach", "CA", 78562);
            User testUser2 = new User("Jessica", "George", "email0@gmail.com", "password2", "3210 brook street", "long beach", "CA", 4562);
            User testUser3 = new User("Annie", "Davis", "email0@gmail.com", "password3", "9999 other street", "fullerton", "CA", 4517);
            User testUser4 = new User("Devin", "Miller", "email0@gmail.com", "password4", "5026 zulu street", "huntington beach", "CA", 4568);
            User testUser5 = new User("Karen", "Smith", "email0@gmail.com", "password5", "5026 zulu street", "huntington beach", "CA", 4568);
            User testUser6 = new User("Josh", "James", "email0@gmail.com", "password6", "123 blue street", "long beach", "CA", 1123);
            User testUser7 = new User("Kane", "Jones", "foreignEmail@gmail.com", "password7", "546 sky street", "New York city", "NY", 45658);
            repo.createUser(testUser0);
            repo.createUser(testUser1);
            repo.createUser(testUser2);
            repo.createUser(testUser3);
            repo.createUser(testUser4);
            repo.createUser(testUser5);
            repo.createUser(testUser6);
            repo.createUser(testUser7);

        }

    }
}
