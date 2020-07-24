using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Core.Interfaces;
using WebApi_Data.Entities;

namespace WebApi.Controllers
{
    [Route("jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        // Dependency Injection
        private readonly ICoreJob _iCore;
        public JobsController(ICoreJob iCore)
        {
            _iCore = iCore;
        }

        // GET: jobs/
        [HttpGet]
        public List<Job> Get()
        {
            return _iCore.GetJobs();
        }

        // GET: jobs/id
        [HttpGet("{id}")]
        public List<Job> Get(int jobId)
        {
            return _iCore.GetJobs(jobId);
        }

        // POST: jobs/
        [HttpPost]
        public Result Post(Job newJob)
        {
            return _iCore.NewJob(newJob);
        }

        // PUT: api/Empleados/5
        [HttpPut("{id}")]
        public Result Put(int editId, Job editJob)
        {
            return _iCore.NewJob(editJob, jobId: editId);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Result Delete(int deleteId)
        {
            return _iCore.DeleteJob(deleteId);
        }
    }
}
