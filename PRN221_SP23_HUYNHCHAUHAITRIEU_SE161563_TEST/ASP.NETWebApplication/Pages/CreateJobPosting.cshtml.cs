using BusinessTier.DTO;
using BusinessTier.Repository;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETWebApplication.Pages
{
    public class CreateJobPostingModel : PageModel
    {
        private readonly ILogger<CreateJobPostingModel> _logger;

        [BindProperty]
        public string Msg { get; set; }

        [BindProperty]
        public JobPostingRequest jobPostingRequest { get; set; }

        private readonly IJobPostingRepository _jobPostingRepository;

        public CreateJobPostingModel(ILogger<CreateJobPostingModel> logger, IJobPostingRepository jobPostingRepository)
        {
            _logger = logger;
            _jobPostingRepository = jobPostingRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var jobPosting = _jobPostingRepository.AddJobPosting(jobPostingRequest);
            if (jobPosting != null)
            {
                Msg = "Add Job Posting success! please return to home page to see detail";
                return Page();
            }
            Msg = "Add Job Posting Error!";
            return Page();
        }
    }
}
