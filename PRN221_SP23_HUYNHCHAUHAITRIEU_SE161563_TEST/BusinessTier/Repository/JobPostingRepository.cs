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
        JobPosting AddJobPosting(JobPostingRequest request);
        JobPosting UpdateJobPosting(UpdateJobPostingRequest request);
    }

    public class JobPostingRepository : IJobPostingRepository
    {
        private readonly CandidateManagementContext _candidateManagementContext;

        public JobPostingRepository(CandidateManagementContext candidateManagementContext)
        {
            _candidateManagementContext = candidateManagementContext;
        }

        public JobPosting AddJobPosting(JobPostingRequest postingRequest)
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

                return jobPosting;
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

        public JobPosting UpdateJobPosting(UpdateJobPostingRequest request)
        {
            try
            {
                var jobPosting = _candidateManagementContext.JobPostings.
                                        FirstOrDefault(x => x.PostingId == request.PostingId);
                if (jobPosting == null)
                {
                    return null;
                }

                //mapping 
                jobPosting.JobPostingTitle = request.JobPostingTitle;
                jobPosting.Description = request.Description;
                jobPosting.PostedDate = DateTime.Now;

                _candidateManagementContext.JobPostings.Update(jobPosting);
                _candidateManagementContext.SaveChanges();

                return jobPosting;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
