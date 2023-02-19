using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTier.Repository
{
    public interface ICandidateProfileRepository
    {
        List<CandidateProfile> GetAllCandidateProfile();
        CandidateProfile SearchCandidateByFullNameOrBirthday(String candidateSearch);
    }

    public class CandidateProfileRepository : ICandidateProfileRepository
    {
        private readonly CandidateManagementContext _candidateManagementContext;

        public CandidateProfileRepository(CandidateManagementContext candidateManagementContext)
        {
            _candidateManagementContext = candidateManagementContext;
        }

        public List<CandidateProfile> GetAllCandidateProfile()
        {
            List<CandidateProfile> candidateList = new List<CandidateProfile>();
            var profile = _candidateManagementContext.CandidateProfiles.ToList();
            foreach (var pf in profile)
            {
                CandidateProfile CDprofile = new CandidateProfile();
                CDprofile.CandidateId = pf.CandidateId;
                CDprofile.Fullname = pf.Fullname;
                CDprofile.Birthday = pf.Birthday;
                CDprofile.ProfileShortDescription = pf.ProfileShortDescription;
                CDprofile.ProfileUrl = pf.ProfileUrl;
                CDprofile.PostingId = pf.PostingId;
                candidateList.Add(pf);
            }
            return candidateList;
        }

        public CandidateProfile SearchCandidateByFullNameOrBirthday(string candidateSearch)
        {
            var profile = _candidateManagementContext.CandidateProfiles.SingleOrDefault(x =>
                                                    x.Fullname.Contains(candidateSearch)
                                                    || x.Birthday.ToString() == candidateSearch );
            if (profile != null)
            {
                return profile;
            }
            return null;
        }
    }
}
