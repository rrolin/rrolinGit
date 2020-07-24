using Microsoft.Extensions.Configuration;
using WebApi_Data.Interface;
using WebApi_Data.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;

namespace WebApi_Data.Domain
{
    public class DataJob : IDataJob
    {
        // Configuration Independency Injection
        private readonly IConfiguration _iConfig;

        public DataJob(IConfiguration iConfig)
        {
            _iConfig = iConfig;
        }

        // Methods
        // Returns a single or several jobs
        public object GetJobs(int jobId = 0)
        {
            // list to return
            List<Job> jobList = new List<Job>();

            // object to return in case of type Result
            object returnObject = new object();

            // Build filter if a search id is provided
            string filterWhere = (jobId > 0) ? $"WHERE JobId = {jobId}" : "";

            DataTable returnData = new DataTable();
            using (SqlConnection con = new SqlConnection(_iConfig["Connection"]))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM Jobs {filterWhere}", con);
                    SqlDataReader dataReader = command.ExecuteReader();
                    returnData.Load(dataReader);

                    // Creates new object to store each row during loop
                    Job job = new Job();
                    foreach (DataRow row in returnData.Rows)
                    {
                        job.JobId = row[""].ToString();
                        job.JobTitle = row[""].ToString();
                        job.JobDescription = row[""].ToString();
                        job.CreatedAt = row[""].ToString();
                        job.ExpiresAt = row[""].ToString();

                        jobList.Add(job);
                        job = default;
                    }

                    // A List exists and will be returned
                    returnObject = jobList;
                }
                catch(Exception ex)
                {
                    // Returns status code and error description
                    returnObject = new Result
                    {
                        StatusCode = 500,
                        StatusDescription = ex.Message
                    };
                }
                finally
                {
                    // Closes SQL Connection no matter the result
                    con.Close();
                }

                return returnObject;
            }
        }

        // Inserts or updates a new job
        public Result InsertEditJob(Job newJob, int jobId = 0)
        {
            Result result = new Result();
            int affectedRows = default;

            using (SqlConnection connection = new SqlConnection(_iConfig["Connection"]))
            {
                try
                {
                    // Opens the connection
                    connection.Open();

                    // No Job Id provided, then is a new one
                    if (jobId is 0)
                    {
                        using (SqlCommand command = new SqlCommand(
                            $"INSERT INTO Jobs VALUES(@JobTitle, @JobDescription, @CreatedAt, @ExpiresAt) ",
                            connection))
                        {
                            command.Parameters.Add(new SqlParameter("JobTitle", newJob.JobTitle));
                            command.Parameters.Add(new SqlParameter("JobDescription", newJob.JobDescription));
                            command.Parameters.Add(new SqlParameter("CreatedAt", newJob.CreatedAt));
                            command.Parameters.Add(new SqlParameter("ExpiresAt", newJob.ExpiresAt));
                            affectedRows = command.ExecuteNonQuery();
                        }
                    }
                    // Job Id provided will be edited
                    else
                    {
                        using (SqlCommand command = new SqlCommand(
                            "UPDATE Jobs SET JobTitle = @JobTitle, JobDescription = @JobDescription, CreatedAt = @CreatedAt, ExpiresAt = @ExpiresAt " +
                            "WHERE JobId = @JobId",
                            connection))
                        {
                            command.Parameters.Add(new SqlParameter("JobTitle", newJob.JobTitle));
                            command.Parameters.Add(new SqlParameter("JobDescription", newJob.JobDescription));
                            command.Parameters.Add(new SqlParameter("CreatedAt", newJob.CreatedAt));
                            command.Parameters.Add(new SqlParameter("ExpiresAt", newJob.ExpiresAt));
                            command.Parameters.Add(new SqlParameter("JobId", jobId));
                            affectedRows = command.ExecuteNonQuery();
                        }
                    }

                    // Return result with affected rows
                    result = new Result
                    {
                        StatusCode = 200,
                        StatusDescription = $"{affectedRows} rows affected."
                    };
                }
                catch (Exception ex)
                {
                    // Return status code and error detail
                    result = new Result
                    {
                        StatusCode = 500,
                        StatusDescription = ex.Message
                    };
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;
        }

        public Result DeleteJob(int jobId = 0)
        {
            Result result = new Result();
            int affectedRows = default;

            using (SqlConnection connection = new SqlConnection(_iConfig["Connection"]))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM Jobs WHERE JobId = @JobId", connection))
                    {
                        command.Parameters.Add(new SqlParameter("JobId", jobId));
                        affectedRows = command.ExecuteNonQuery();
                    }

                    result = new Result()
                    {
                        StatusCode = 200,
                        StatusDescription = $"{affectedRows} rows affected"
                    };
                }
                catch(Exception ex)
                {
                    result = new Result()
                    {
                        StatusCode = 500,
                        StatusDescription = ex.Message
                    };
                }
                finally
                {
                    connection.Close();
                }
            }
            
            // Return result with status detail
            return result;
        }
    }
}
