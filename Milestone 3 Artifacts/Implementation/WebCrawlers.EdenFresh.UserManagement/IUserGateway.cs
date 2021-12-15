using System.Data;
namespace WebCrawlers.EdenFresh.UserManagement

{
    interface IUserGateway
    {
    	public Boolean WriteToDataStore(int userId, string email, string password, bool isEnabled);
    	public Boolean UpdateDataStore(int userID, string email, string password, bool isEnabled);
    	public Boolean DeleteFromDataStore(int userID, string email, string password);
    }
}