using BusinessTier.DTO;
using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTier.Repository
{
    public interface IJobPostingRepository
    {
        List<JobPosting> GetAllJobs();
        JobPostingRequest AddJobPosting(JobPostingRequest postingRequest);
    }

    public class JobPostingRepository : IJobPostingRepository
    {
        private readonly CandidateManagementContext _candidateManagementContext;

        public JobPostingRepository(CandidateManagementContext candidateManagementContext)
        {
            _candidateManagementContext = candidateManagementContext;
        }

        public JobPostingRequest AddJobPosting(JobPostingRequest postingRequest)
        {
            //mapping 
            JobPosting jobPosting = new JobPosting();
            postingRequest.PostingId = jobPosting.PostingId;
            postingRequest.JobPostingTitle = jobPosting.JobPostingTitle;
            postingRequest.Description = jobPosting.Description;
            postingRequest.PostedDate = jobPosting.PostedDate;
            _candidateManagementContext.JobPostings.Add(jobPosting);
            _candidateManagementContext.SaveChanges();

            return postingRequest;
        }

        public List<JobPosting> GetAllJobs()
        {
            List<JobPosting> jobPostingList = new List<JobPosting>();
            var result = _candidateManagementContext.JobPostings.ToList();
            foreach (var job in result)
            {
                JobPosting jobPosting = new JobPosting();
                jobPosting.PostingId = job.PostingId;
                jobPosting.JobPostingTitle = job.JobPostingTitle;
                jobPosting.Description = job.Description;
                jobPosting.PostedDate = job.PostedDate;
                jobPostingList.Add(jobPosting);
            }
            return jobPostingList;
        }
    }
}
