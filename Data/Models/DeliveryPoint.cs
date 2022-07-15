namespace wandaTechIntern.Data.Models
{
    public class DeliveryPoint
    {
        public int Id { get; set; }

        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }

        public string ContactName { get; set; }
        public string ContactPhone { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
