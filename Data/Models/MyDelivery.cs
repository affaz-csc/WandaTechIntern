using Microsoft.AspNetCore.Identity;

namespace wandaTechIntern.Data.Models
{
    public class MyDelivery
    {
        public int Id { get; set; }
        
        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }


        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
