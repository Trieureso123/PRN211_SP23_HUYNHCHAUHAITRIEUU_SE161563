using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DataAccess.DataAccess
{
    public partial class HRAccount
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int? MemberRole { get; set; }
    }
}
