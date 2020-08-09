using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public JobModel[] GetJobs()
        {
            return (from job in context.Jobs
                    join customer in context.Customers on job.CustomerId equals customer.CustomerId
                    into job_customer_joined
                    from groupjoined in job_customer_joined.DefaultIfEmpty()
                    select new JobModel
                    {
                        JobId = job.JobId,
                        Engineer = job.Engineer,
                        When = job.When,
                        CustomerName = groupjoined == null ? "Unknown" : groupjoined.Name,
                        CustomerType = groupjoined == null ? "Unknown" : groupjoined.Type
                    }).ToArray();
        }

        public JobModel GetJob(int jobId)
        {
            return (from job in context.Jobs.Where(x=> x.JobId == jobId)
                    join customer in context.Customers on job.CustomerId equals customer.CustomerId
                    into job_customer_joined
                    from groupjoined in job_customer_joined.DefaultIfEmpty()

                    select new JobModel
                    {
                        JobId = job.JobId,
                        Engineer = job.Engineer,
                        When = job.When,
                        CustomerName = groupjoined == null ? "Unknown" : groupjoined.Name,
                        CustomerType = groupjoined == null ? "Unknown" : groupjoined.Type
                    }).FirstOrDefault();

        }

        public JobModel CreateJob(BaseJobModel model)
        {
            var addedJob = context.Jobs.Add(new Job
            {
                Engineer = model.Engineer,
                When = model.When,
                CustomerId = model.CustomerId
            });

            context.SaveChanges();
            return GetJob(addedJob.Entity.JobId);
        }
    }
}
