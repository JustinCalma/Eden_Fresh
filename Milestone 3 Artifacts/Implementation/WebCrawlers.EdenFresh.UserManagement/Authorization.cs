using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlers.EdenFresh.UserManagement
{
    internal class Authorization : Authentication
    {
        private Authentication umAuthen;
        private int userId;
        private Random rnd = new Random();

        private Stopwatch stopwatch;

        public umAuthorization(Authentication umAuthen)
        {
            this.umAuthentication = umAuthen;
            userId = rnd.Next(100000, 999999);
        }

        public Boolean AuthorizeUser(string userId)
        {
            return(umAuthentication.AuthenthicationUser(userId));
        }
    }
}
