using System;

namespace Renting.Master.Domain.Helpers
{
    public interface ILoggerHelper
    {
        void LogError(string metodo, Exception e);
        void LogInfo(string metodo, string message);
    }
}
