using System.Collections.Generic;
using WebApi_Data.Entities;

namespace WebApi_Core.Interfaces
{
    public interface ICoreJob
    {
        List<Job> GetJobs(int jobId = 0);

        Result NewJob(Job newJob, int jobId = 0);

        Result DeleteJob(int jobId = 0);
    }
}
