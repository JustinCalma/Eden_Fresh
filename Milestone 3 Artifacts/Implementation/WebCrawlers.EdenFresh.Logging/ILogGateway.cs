
using System.Data;
namespace WebCrawlers.EdenFresh.Logging

{
    public enum Comparator {LESS, GREATER, EQUAL, NOT}
    public interface ILogGateway
    {
        public Boolean WriteLog(int userId, DateTime timeStamp, LogWriter.LogLevel logLevel, LogWriter.Category category, string message);
        public DataTable ReadLogsWhere(string columnName, Comparator compare, string value);
        public int DeleteLogsWhere(string columnName, Comparator compare, string value);
    }
}
