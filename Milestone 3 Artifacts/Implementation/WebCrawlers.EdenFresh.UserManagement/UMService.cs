using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlers.EdenFresh.UserManagement
{
    class UMService
    {
        IUserGateway umDao;

        public UMService(IUserGateway gateway)
        {
            umDao = gateway;
        }
        public Boolean CreateAccount(int userId, String email, String password, Boolean isEnabled)
        {
            return umDao.WriteToDataStore(userId, email, password, isEnabled);
        }

        public Boolean DeleteAccount(int userId, String email, String password, Boolean isEnabled)
        {
            return umDao.DeleteFromDataStore(userId, email, password, isEnabled);
        }

        public Boolean UpdateAccount(int userId, String email, String password, Boolean isEnabled)
        {
            return umDao.UpdateDataStore(userId, email, password, isEnabled);
        }
    }
}
