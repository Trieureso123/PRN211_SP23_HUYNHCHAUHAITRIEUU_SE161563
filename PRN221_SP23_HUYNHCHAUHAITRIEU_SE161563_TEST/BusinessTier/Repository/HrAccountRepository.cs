using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTier.Repository
{
    public interface IHrAccountRepository
    {
        HRAccount Login (string email, string password);
        List<HRAccount> GetAllAccount();
    }

    public class HrAccountRepository : IHrAccountRepository
    {
        private readonly CandidateManagementContext _candidateManagementContext;

        public HrAccountRepository(CandidateManagementContext candidateManagementContext)
        {
            _candidateManagementContext = candidateManagementContext;
        }

        public HRAccount Login(string email, string password)
        {
            var account = _candidateManagementContext.Hraccounts
                            .SingleOrDefault(c => c.Email == email 
                            && c.Password == password 
                            && c.MemberRole == 2);
            if (account != null)
            {
                return account; 
            }
            return null;
        }

        public List<HRAccount> GetAllAccount()
        {
            List<HRAccount> listAccount = new List<HRAccount>();
            var books = _candidateManagementContext.Hraccounts.ToList();
            foreach (var book in books)
            {
                HRAccount hrAccount = new HRAccount();
                hrAccount.Email = book.Email;
                hrAccount.FullName = book.FullName;
                hrAccount.Password = book.Password;
                hrAccount.MemberRole = book.MemberRole;
                listAccount.Add(hrAccount);
            }
            return listAccount;
        }
    }

    
}
