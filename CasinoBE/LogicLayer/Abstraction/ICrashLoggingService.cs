using Models.Entities;
using System.Collections.Generic;

namespace LogicLayer.Abstraction
{
    public interface ICrashLoggingService
    {
        void log(string crashMsg);
        List<CrashLog> getAll();
    }
}
