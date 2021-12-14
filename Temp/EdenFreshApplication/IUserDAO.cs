

namespace EdenFreshApplication
{
    interface IUserDAO
    {
        public void getAllUsers();
        void deleteUser(int userId);
        void createUser(User user);
        void readUser(int userId);
        void updateUser(User user);
    }
}
