using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlers.EdenFresh.UserManagement
{
    public class Authentication
    {
        public Authentication() { }
        public Boolean AuthenticateUser(int userID)
        {
            return userID == 0;
        }
    }
}
