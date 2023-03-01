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
            try
            {
                //mapping 
                JobPosting jobPosting = new JobPosting();
                jobPosting.PostingId = postingRequest.PostingId;
                jobPosting.JobPostingTitle = postingRequest.JobPostingTitle;
                jobPosting.Description = postingRequest.Description;
                jobPosting.PostedDate = DateTime.Now;

                //add Job Posting
                _candidateManagementContext.JobPostings.Add(jobPosting);
                _candidateManagementContext.SaveChanges();

                return postingRequest;
            }
            catch (Exception ex)
            {
                return null;
            }
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
