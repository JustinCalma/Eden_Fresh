using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdenFresh
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
