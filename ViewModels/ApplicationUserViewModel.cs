using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Data.Models;

namespace Talent.Web.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string UserDescription { get; set; }
        public int Rating { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }

        public UserAddress PrimaryAddress { get; set; }
    }
}
