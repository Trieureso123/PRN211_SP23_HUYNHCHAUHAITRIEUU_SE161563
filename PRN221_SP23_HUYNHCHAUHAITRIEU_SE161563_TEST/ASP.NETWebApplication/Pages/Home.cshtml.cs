using BusinessTier.Repository;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ASP.NETWebApplication.Pages
{
    public class HomeModel : PageModel
    {
        private readonly ILogger<HomeModel> _logger;

        [BindProperty]
        public string Msg { get; set; }

        [BindProperty]
        public CandidateProfile candidateProfile { get; set; }
        [BindProperty]
        public string searchCandidateProfle { get; set; }
        public List<CandidateProfile> candidateProfileListResult;
        public CandidateProfile profile = new CandidateProfile();

        private readonly ICandidateProfileRepository _candidateProfileRepository;

        public HomeModel(ILogger<HomeModel> logger, ICandidateProfileRepository candidateProfileRepository)
        {
            _logger = logger;
            _candidateProfileRepository = candidateProfileRepository;
        }

        public IActionResult OnGet()
        {
            candidateProfileListResult = _candidateProfileRepository.GetAllCandidateProfile();
            if (candidateProfileListResult == null)
            {
                Msg = "There is no data for you to display, please check your database first to make sure" +
                    "there are some available data!";
                return Page();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            candidateProfile = _candidateProfileRepository.SearchCandidateByFullNameOrBirthday(searchCandidateProfle);
            if(candidateProfile == null)
            {
                Msg = "There is no data matched with your request!";
                OnGet();
                return Page();
            }
            OnGet();
            return Page();
        }

        public IActionResult OnDelete()
        {
            for(int i = 0; i < candidateProfileListResult.Count; i++) 
            {
                if (candidateProfileListResult[i].CandidateId == searchCandidateProfle)
                {
                    candidateProfileListResult.RemoveAt(i); 
                    Msg = "The Data has been deleted!";
                    OnGet();
                    return Page();
                }       
            }
            Msg = "There is no data to delete";
            OnGet();
            return Page();
        }
    }
}
