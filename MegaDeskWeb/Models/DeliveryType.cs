using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MegaDeskWeb.Models
{
    public class DeliveryType
    {
        public int DeliveryTypeId { get; set; }

        [Display(Name = "Delivery Name")]
        public string DeliveryName { get; set; }

        public decimal PriceUnder1000 { get; set; }

        public decimal PriceBetween1000and2000 { get; set; }

        public decimal PriceOver2000 { get; set; }

    }
}
