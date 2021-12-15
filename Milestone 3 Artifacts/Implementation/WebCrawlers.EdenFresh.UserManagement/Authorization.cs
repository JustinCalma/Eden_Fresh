using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlers.EdenFresh.UserManagement
{
    public class Authorization
    {
        private Authentication umAuthen;

        public Authorization(Authentication umAuthen)
        {
            this.umAuthen = umAuthen;
        }

        public Boolean AuthorizeUser(int userId)
        {
            return this.umAuthen.AuthenticateUser(userId);
        }
    }
}
