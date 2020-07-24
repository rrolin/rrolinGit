using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace WebApi_Core.Entities
{
    public class Job
    {
        public string JobId { get; }

        public string JobTitle { get; set; }

        public string JobDescription { get; set; }

        public string CreatedAt { get; set; }
        
        public string ExpiresAt { get; set; }
    }
}
