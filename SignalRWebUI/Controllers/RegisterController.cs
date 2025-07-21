using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto dto)
        {
            AppUser appUser = new AppUser
            {
                Name = dto.Name,
                Surname = dto.Surname,
                UserName = dto.Username,
                Email = dto.Email,
            };
            var Result = await _userManager.CreateAsync(appUser, dto.Password);
            if (Result.Succeeded)
            {
                return RedirectToAction("Index", "Login"); // Redirect to the login page after successful registration                 
            }
            return View();
        }
    }
}
