using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
    public class SettingController : Controller
    {
        //"Ben kullanıcı işlemlerimi AppUser sınıfına göre yapacağım."
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            EditProfileDto editProfileDto = new EditProfileDto()
            {
                Name = value.Name,
                Surname = value.Surname,
                Username = value.UserName,
                Mail = value.Email,
            };
            return View(editProfileDto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(EditProfileDto editProfileDto)
        {
            if (editProfileDto.Password == editProfileDto.ConfirmPassword)
            {
                var value =await _userManager.FindByNameAsync(User.Identity.Name);
                value.Name = editProfileDto.Name;
                value.Surname = editProfileDto.Surname;
                value.UserName = editProfileDto.Username;
                value.Email = editProfileDto.Mail;
                value.PasswordHash = _userManager.PasswordHasher.HashPassword(value,editProfileDto.Password);
                await _userManager.UpdateAsync(value);
                return RedirectToAction("Index", "Statistics");
            }
            return View();
        }
    }
}
