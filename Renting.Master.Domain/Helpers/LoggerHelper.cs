using System;

namespace Renting.Master.Domain.Helpers
{
    public class LoggerHelper : ILoggerHelper
    {
        private static readonly log4net.ILog logAppender = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void LogError(string metodo, Exception e)
        {
            //logAppender.Error(metodo + " >> [" + e + "]");
            logAppender.Info("Some information message");
            logAppender.Warn("A warning message");
            logAppender.Error("An error message");
        }
        public void LogInfo(string metodo, string message)
        {
            //logAppender.Info(metodo + " >> [" + message+"]");
            logAppender.Info("Some information message");
            logAppender.Warn("A warning message");
            logAppender.Error("An error message");
        }
    }
}
