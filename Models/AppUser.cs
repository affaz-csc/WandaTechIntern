using Microsoft.AspNetCore.Identity;
using wandaTechIntern.Data;

namespace wandaTechIntern.Service
{
    public class AppUser : IdentityUser<string>
    {
        public string OtpTempField { get; set; }
        public bool IsActive { get; set; }
    }
}