using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talent.Data.Models;
using Talent.Services.Repository.IRepository;

namespace Talent.Web.Controllers
{
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAppUserRepository _userService;
        private readonly IConfiguration _configuration;

        public ProfileController(UserManager<ApplicationUser> userManager, IAppUserRepository userService, IConfiguration configuration)
        {
            _userManager = userManager;
            _userService = userService;
            _configuration = configuration;
        }
    }
}