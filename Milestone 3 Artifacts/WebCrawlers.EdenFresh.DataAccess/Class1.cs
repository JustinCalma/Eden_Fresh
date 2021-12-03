using System.Data;

namespace WebCrawlers.EdenFresh.DataAccess
{
    interface ILogGateway
    {
        public DataSet getAllLogs();
        void deleteLogs(int userId);
        void writeLogs(int userID);
        void readLogs(int userId);
    }
}