using BusinessTier.Repository;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace ASP.NETWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
       
        [BindProperty]
        public string Msg { get; set; }

        [BindProperty]
        public HRAccount account { get; set; }

        private readonly IHrAccountRepository _accountRepository;

        public IndexModel(ILogger<IndexModel> logger, IHrAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var acc = _accountRepository.Login(account.Email, account.Password);
            if (acc == null)
            {
                Msg = "Invalid Email or Password, You are not allowed to do this function because you are not the manager!";
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("Email", acc.Email);
                return RedirectToPage("Home");
            }
        }
    }
}
