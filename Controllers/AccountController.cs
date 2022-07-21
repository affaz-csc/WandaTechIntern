using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using wandaTechIntern.Data;
using wandaTechIntern.Models;
using wandaTechIntern.Service;

namespace wandaTechIntern.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserService userService;
        public AccountController(ApplicationDbContext context, UserService userService)
        {
            this.userService = userService;
            this.context = context;
        }
        
        public IActionResult Register()
        {
            ViewBag.ErrorMessage = userService.ErrorMessage;
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserVm vm)
        {
            var result = userService.VerifyUserAndSentOtpCode(vm.Phone, vm.Email, vm.Password, vm.Name);
            if(result == false){
                // ModelState.AddModelError("", userService.ErrorMessage);
                ViewBag.ErrorMessage = userService.ErrorMessage;
                return View();
            }

            return RedirectToAction("VerifyOtp", new { id = userService.UserId });
        }

        public IActionResult VerifyOtp(string id)
        {
            var vm = new OtpEnterVm {
                UserId = id,
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> VerifyOtp(OtpEnterVm vm)
        {
            var result = await userService.VerifyOtpAndSaveUser(vm.OtpCode, vm.UserId);
            if(result == false){
                // ModelState.AddModelError("", userService.ErrorMessage);
                ViewBag.ErrorMessage = userService.ErrorMessage;
                return View(vm);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
