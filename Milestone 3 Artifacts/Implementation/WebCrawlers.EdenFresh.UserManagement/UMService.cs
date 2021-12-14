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
        MSSQLUMGateway umDao = new MSSQLUMGateway(@"Data Source=.\SQLEXPRESS;Initial Catalog=logging;Integrated Security=True;Pooling=False");
        public Boolean CreateAccount(String userName, String email, String password, Boolean isEnabled)
        {
            umDao.WriteToDataStore(userName, email, password, isEnabled);
            return true;

        }
    }
}
