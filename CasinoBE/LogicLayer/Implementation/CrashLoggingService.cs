using LogicLayer.Abstraction;
using LogicLayer.Repositories;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicLayer.Implementation
{
    class CrashLoggingService : ICrashLoggingService
    {
        public readonly RepositoryBase<CrashLog> repository;
        public CrashLoggingService()
        {
            repository = new RepositoryBase<CrashLog>();
        }
        public List<CrashLog> getAll() => repository.GetAll().ToList();
        public void log(string crashMsg)
        {
            repository.Add(new CrashLog { crash_msg = crashMsg, crash_time = DateTime.Now });
            repository.Save();
            repository.Commit();
        }
    }
}
