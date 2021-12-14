﻿using System.Data;
namespace WebCrawlers.EdenFresh.Logging

{
    public enum Comparator {LESS, GREATER, EQUAL, NOT}
    interface ILogGateway
    {
        public Boolean WriteLog(int userId, DateTime timeStamp, LogLevel logLevel, Category category, string message);
        public DataTable ReadLogsWhere(string columnName, Comparator compare, string value);
        public Boolean DeleteLogsWhere(string columnName, Comparator compare, string value);
    }
}