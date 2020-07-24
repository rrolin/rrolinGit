using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi_Data.Entities
{
    public class Job
    {
        public string JobId { get; set; }

        public string JobTitle { get; set; }

        public string JobDescription { get; set; }

        public string CreatedAt { get; set; }

        public string ExpiresAt { get; set; }
    }
}
