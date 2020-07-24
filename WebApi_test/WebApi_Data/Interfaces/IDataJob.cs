using WebApi_Data.Entities;

namespace WebApi_Data.Interface
{
    public interface IDataJob
    {
        object GetJobs(int jobId = 0);

        Result InsertEditJob(Job newJob, int jobId = 0);

        Result DeleteJob(int jobId = 0);
    }
}
