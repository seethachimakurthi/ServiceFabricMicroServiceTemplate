using System;

namespace Renting.Master.Domain.Helpers
{
    public class LoggerHelper : ILoggerHelper
    {
        private static readonly log4net.ILog logAppender = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void LogError(string metodo, Exception e)
        {
            logAppender.Error(metodo + " >> [" + e + "]");
        }
        public void LogInfo(string metodo, string message)
        {
            logAppender.Info(metodo + " >> [" + message+"]");
        }
        public void LogWarn(string metodo, string message)
        {
            logAppender.Warn(metodo + " >> [" + message+"]");
        }
    }
}
