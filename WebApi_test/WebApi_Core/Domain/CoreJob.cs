using System;
using System.Collections.Generic;
using System.Text;
using WebApi_Core.Interfaces;
using WebApi_Data.Entities;
using WebApi_Data.Interface;

namespace WebApi_Core.Domain
{
    public class CoreJob : ICoreJob
    {
        // Dependency Injection to Data Access
        private readonly IDataJob _iDataJob;
        public CoreJob(IDataJob iDataJob)
        {
            _iDataJob = iDataJob;
        }

        public List<Job> GetJobs(int jobId = 0)
        {
            return null;
        }

        public Result NewJob(Job newJob, int jobId = 0)
        {
            return null;
        }

        public Result DeleteJob(int jobId = 0)
        {
            return null;
        }
    }
}
