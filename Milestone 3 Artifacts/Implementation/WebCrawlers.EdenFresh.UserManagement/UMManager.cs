﻿using System.Diagnostics;
using WebCrawlers.EdenFresh.Logging;

namespace WebCrawlers.EdenFresh.UserManagement
{
    internal class UMManager
    {
        private Stopwatch stopwatch;
        private UMService umService;
        private int userId;
        private Authorization authorization;

        ILogGateway dao;
        LogWriter writer;
        public UMManager(int userID, UMService uMService, Authorization auth)
        {
            this.stopwatch = new Stopwatch();
            this.umService = uMService;
            this.userId = userID;
            this.authorization = auth;
        }

        public Boolean CreateAccount(String email, String password, Boolean isEnabled)
        {
            try
            {
                stopwatch.Restart();
                stopwatch.Start();
                bool operationSuccessful = umService.CreateAccount(userId, email, password, isEnabled);
                stopwatch.Stop();
                writer.Write(userId, LogWriter.LogLevel.Info, LogWriter.Category.DataStore, "Creating New User Account");
                return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
            }
            catch (Exception ex)
            {
                writer.Write(userId, LogWriter.LogLevel.Error, LogWriter.Category.DataStore, "Error In Creating New User Account");
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public Boolean DeleteAccount(int userId, String email, String password, Boolean isEnabled)
        {
            try
            {
                stopwatch.Restart();
                stopwatch.Start();
                bool operationSuccessful = umService.DeleteAccount(userId, email, password, isEnabled);
                stopwatch.Stop();
                writer.Write(userId, LogWriter.LogLevel.Info, LogWriter.Category.DataStore, "Deleting User Account");
                return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
            }
            catch(Exception ex)
            {
                writer.Write(userId, LogWriter.LogLevel.Error, LogWriter.Category.DataStore, "Error In Deleting New User Account");
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public Boolean UpdateAccount(int userId, String email, String password, Boolean isEnabled)
        {
            try
            {
                stopwatch.Restart();
                stopwatch.Start();
                bool operationSuccessful = umService.UpdateAccount(userId, email, password, isEnabled);
                stopwatch.Stop();
                writer.Write(userId, LogWriter.LogLevel.Info, LogWriter.Category.Data, "Updating User Account");
                return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
            }
            catch (Exception ex)
            {
                writer.Write(userId, LogWriter.LogLevel.Error, LogWriter.Category.Data, "Error In Updating User Account");
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public Boolean EnableAccount(int userId, String email, String password)
        {
            try
            {
                stopwatch.Restart();
                stopwatch.Start();
                bool operationSuccessful = umService.UpdateAccount(userId, email, password, true);
                stopwatch.Stop();
                writer.Write(userId, LogWriter.LogLevel.Info, LogWriter.Category.Data, "Enabling User Account");
                return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
            }
            catch(Exception ex)
            {
                writer.Write(userId, LogWriter.LogLevel.Error, LogWriter.Category.Data, "Error In Enabling User Account");
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public Boolean DisableAccount(int userId, String email, String password)
        {
            try
            {
                stopwatch.Restart();
                stopwatch.Start();
                bool operationSuccessful = umService.UpdateAccount(userId, email, password, false);
                stopwatch.Stop();
                writer.Write(userId, LogWriter.LogLevel.Info, LogWriter.Category.Data, "Disable User Account");
                return (operationSuccessful && stopwatch.ElapsedMilliseconds <= 5000);
            }
            catch(Exception ex)
            {
                writer.Write(userId, LogWriter.LogLevel.Error, LogWriter.Category.Data, "Error In Disabling User Account");
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
