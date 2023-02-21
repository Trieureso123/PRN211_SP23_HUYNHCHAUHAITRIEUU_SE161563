using BusinessTier.Repository;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrAccountController : ControllerBase
    {
        private readonly IJobPostingRepository _bookService;

        public HrAccountController(IJobPostingRepository bookService)
        {
            _bookService = bookService;
        }
        // GET: api/<BooksController>
        //[HttpGet]
        //public ActionResult<List<HRAccount>> Get()
        //{
        //    var list = _bookService.GetAllAccount();
        //    return Ok(list);
        //}
        [HttpGet]
        public ActionResult<List<JobPosting>> Get()
        {
            var list = _bookService.GetAllJobs();
            return Ok(list);
        }

    }
}
