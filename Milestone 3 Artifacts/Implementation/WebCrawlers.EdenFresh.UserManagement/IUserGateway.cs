using System.Data;
namespace WebCrawlers.EdenFresh.UserManagement

{
    interface IUserGateway
    {
    	public CreateAccount(string userID, string email, string password);
    	public UpdateAccount(string userID, string email, string password);
    	public DeleteAccount(string userID, string email, string password);
    }
}