using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Data.Models;
using Talent.Web.ViewModels;

namespace Talent.Web.Mapper
{
    public class ApplicatioUserMapper:Profile
    {
        public ApplicatioUserMapper()
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();
        }

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
