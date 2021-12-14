using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlers.EdenFresh.UserManagement
{
    class UMService
    {
        private String connectionString;
        MSSQLUMGateway umDao;

        public UMService(String conectionString)
        {
            umDao = new MSSQLUMGateway(conectionString);
        }
        public Boolean CreateAccount(String userName, String email, String password, Boolean isEnabled)
        {
            return umDao.WriteToDataStore(userName, email, password, isEnabled);
        }
    }
}
