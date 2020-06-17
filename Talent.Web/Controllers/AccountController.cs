using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Talent.Data.Models;
using Talent.Web.ViewModels;

namespace Talent.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly IEmailSender _emailSender;
        //private readonly ILogger _logger;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,/* IEmailSender emailSender, /*ILogger logger*/ IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_emailSender = emailSender;
            //_logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            // If we got this far, something failed, redisplay form
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromQuery] UserRegisterViewModel model/*, string returnUrl = null*/)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { 
                    UserName = model.Username, 
                    Email = model.Email, 
                    //CreatedOn = DateTime.Now, 
                    //IsActive = true 
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //_logger.LogInformation("User created a new account with password.");

                    //if (result.Succeeded)
                    //{
                    //    if(_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    //    {
                    //        return RedirectToAction("GetAllUsers", "Administration");
                    //    }
                    //}

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok("User created.");

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    //var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    //_logger.LogInformation("User created a new account with password.");
                    //return RedirectToLocal(returnUrl);
                }

                //AddErrors(result);
                // If we got this far, something failed, redisplay form
            }
            return RedirectToAction("Index", "Home");
        }
    }
}