using System.Data;
namespace WebCrawlers.EdenFresh.UserManagement

{
    interface IUserGateway
    {
    	public Boolean WriteToDataStore(string userID, string email, string password, bool isEnabled);
    	public Boolean UpdateDataStore(string userID, string email, string password, bool isEnabled);
    	public Boolean DeleteFromDataStore(string userID, string email, string password, bool isEnabled);
    }
}