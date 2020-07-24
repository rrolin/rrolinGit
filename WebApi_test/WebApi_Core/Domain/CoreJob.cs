using System;
using WebApi_Core.Extension;
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

        public object GetJobs(int jobId = 0)
        {
            return _iDataJob.GetJobs(jobId);
        }

        public Result NewJob(Job newJob, int jobId = 0)
        {
            // Validate if both dates required are valid
            // If they are not, then are replaced with current date and time.
            if (!newJob.CreatedAt.isValidDate())
                newJob.CreatedAt = DateTime.Now.ToString();

            if (!newJob.ExpiresAt.isValidDate())
                newJob.ExpiresAt = DateTime.Now.ToString();

            return _iDataJob.InsertEditJob(newJob, jobId);
        }

        public Result DeleteJob(int jobId = 0)
        {
            return _iDataJob.DeleteJob(jobId);
        }
    }
}
