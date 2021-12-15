using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlers.EdenFresh.UserManagement
{
    internal class bool AuthenticationUser(string userID)
    {
        bool truth = true;

        userID = userID.ToLower();
        if (string.IsNullOrEmpty(userID)) { return false; }

        return truth;


    }
}