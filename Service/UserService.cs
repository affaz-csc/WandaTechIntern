using Microsoft.AspNetCore.Identity;
using wandaTechIntern.Data;

namespace wandaTechIntern.Service
{
    public class UserService
    {
        private readonly ApplicationDbContext context;
        private readonly SignInManager<AppUser> signInManager;

        public UserService(ApplicationDbContext context, SignInManager<AppUser> signInManager)
        {
            this.context = context;
            this.signInManager = signInManager;
        }
        string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };  

        public string ErrorMessage { get; set; }
        public string UserId { get; set; }
        private string GenerateRandomOTP(int iOTPLength,string[] saAllowedCharacters )  
        {  
            string sOTP = String.Empty;  
            string sTempChars = String.Empty;  
            Random rand = new Random();  
            for (int i = 0; i < iOTPLength; i++)  
            {  
                int p = rand.Next(0, saAllowedCharacters.Length);  
                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];  
                sOTP += sTempChars;  
            }  
            return sOTP;  
        }  


        /// <summary>
        /// chcek if user exits -> retuns error
        /// save to db with otp > return to next
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool VerifyUserAndSentOtpCode(string phone, string email, string password, string name)
        {
            // steps to do
            // 1: check if user exists in db **
            // 2: veryfy password strength
            // 3: generate OTP code, save temp user and return

            // step 1:
            if(context.Users.Any(t=> t.Email == email && t.PhoneNumber == phone))
            {
                ErrorMessage = "Entered email or phone is already taken!";
                return false;
            }

            // step 3: generate otp
            string sRandomOTP = GenerateRandomOTP(6, saAllowedCharacters); 
            // Todo: send otp via email


            // save user to db
            UserId = Guid.NewGuid().ToString();
            var userToSave = new AppUser{
                Id = UserId,
                Email = email,
                PhoneNumber = phone,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = email,
                IsActive = false,
                OtpTempField = sRandomOTP,
            };
            context.Users.Add(userToSave);
            context.SaveChanges();

            return true;
        }

        public async Task<bool> VerifyOtpAndSaveUser(string otpCode, string userId)
        {
            // context.Users.Add(new IdentityUser{ });
            // context.SaveChanges();
            
            // steps to do
            // 1: find the user from id and validate
            // 2: verify otp code generated on step1
            // 3: login user

            var userInDb = context.Users.Find(userId);
            if(userInDb == null){
                ErrorMessage = "User was not found!";
                return false;
            }

            // check OTP entered vs in db
            if(userInDb.OtpTempField != otpCode){
                ErrorMessage = "OTP was invalid!";
                return false;
            }
            
            userInDb.IsActive = true;
            userInDb.OtpTempField = "";
            await context.SaveChangesAsync();
            await signInManager.SignInAsync(userInDb, false);
            return true;
        }
    }
}
