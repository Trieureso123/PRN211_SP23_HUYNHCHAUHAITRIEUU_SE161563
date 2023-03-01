using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTier.DTO
{
    public class JobPostingRequest
    {
        [Required]
        //[RegularExpression("[C]\\w+", ErrorMessage = "Id must start at Cxxx!")]
        public string PostingId { get; set; }

        [Required]
        //[RegularExpression("([A-Z])\\w+", ErrorMessage = "Job Posting Title must begin with the capital letter")]
        public string JobPostingTitle { get; set; }

        [Required]
        //[StringLength(200, MinimumLength = 12, ErrorMessage = "Job Posting Description between 12 - 20 characters")]
        public string Description { get; set; }

        //[Display(Name = "Date")]
        //[Required]
        //[DataType(DataType.DateTime)]
        //public DateTime? PostedDate { get; set; }
    }
}
