using BusinessTier.Repository;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateProfileController : ControllerBase
    {
        private readonly ICandidateProfileRepository _candidateProfileContext;

        public CandidateProfileController(ICandidateProfileRepository candidateProfileContext)
        {
            _candidateProfileContext = candidateProfileContext;
        }
        
        [HttpGet]
        public ActionResult<List<CandidateProfile>> Get()
        {
            var list = _candidateProfileContext.GetAllCandidateProfile();
            return Ok(list);
        }
    }
}
