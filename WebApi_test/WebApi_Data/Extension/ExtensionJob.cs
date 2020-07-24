using System;
using System.Collections.Generic;
using System.Text;
using WebApi_Data.Entities;

namespace WebApi_Data.Extension
{
    public static class ExtensionJob
    {
        public static bool insertUpdateJob(this Job job, bool isNew = true)
        {
            return true;
        }

        public static bool deleteJob(int jobId)
        {
            return true;
        }
    }
}
