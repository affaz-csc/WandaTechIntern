using Microsoft.AspNetCore.Identity;
using wandaTechIntern.Data;

namespace wandaTechIntern.Service
{
    public class UserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string ErrorMessage { get; set; }
        public bool VerifyUserAndSentOtpCode(string phone, string email, string password, string name)
        {
            if(context.Users.Any(t=> t.Email == email && t.PhoneNumber == phone))
            {
                ErrorMessage = "Entered email or phone is already taken!";
                return false;
            }

            return true;
            // steps to do
            // 1: check if user exists in db **
            // 2: veryfy password strength
            // 3: generate OTP code and return
        }

        public void VerifyOtpAndSaveUser(string otpCode, string phone, string email, string password, string name)
        {
            // context.Users.Add(new IdentityUser{ });
            // context.SaveChanges();
            
            // steps to do
            // 1: verify otp code generated on step1
            // 2: create user 
            // 3: login user
        }
    }
}
