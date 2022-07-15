using System.ComponentModel.DataAnnotations;

namespace wandaTechIntern.Data.Models
{
    public class Delivery
    {
        public int Id { get; set; }

        public DateTime TimeOfDelivery { get; set; }
        public DateTime PostedTime { get; set; }

        public int TotalPoints { get; set; }
        public decimal TotalValue { get; set; }

        public ICollection<DeliveryPoint> DeliveryPoints { get; set; }

        public Delivery()
        {
            DeliveryPoints = new List<DeliveryPoint>();
        }
    }
}
