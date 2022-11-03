namespace MegaDeskWeb.Models
{
    public class DeliveryType
    {
        public int DeliveryTypeId { get; set; }

        public string DeliveryName { get; set; }

        public decimal PriceUnder1000 { get; set; }

        public decimal PriceBetween1000and2000 { get; set; }

        public decimal PriceOver2000 { get; set; }

    }
}
