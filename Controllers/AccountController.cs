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

            return RedirectToAction("VerifyOtp");
        }

        public IActionResult VerifyOtp()
        {
            return View();
        }

    }
}
