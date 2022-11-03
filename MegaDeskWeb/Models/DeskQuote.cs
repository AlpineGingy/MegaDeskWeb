using System.ComponentModel.DataAnnotations;
using MegaDeskWeb.Data;

namespace MegaDeskWeb.Models
{
    public class DeskQuote
    {
        // constants
        private const decimal BASE_DESK_PRICE = 200.00M;
        private const decimal SURFACE_AREA_COST = 1.00M;
        private const decimal DRAWER_COST = 50.00M;

        // properties
        public string DeskQuoteId { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Quote Date")]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Quote Price")]
        [DisplayFormat(DataFormatString ="{0:C}")]
        public decimal QuotePrice { get; set; }

        [Required]
        public int DeskId { get; set; }

        [Display(Name = "Delivery Type")]
        public int DeliveryTypeId { get; set; }

        // Nav properties

        public Desk Desk { get; set; }

        public DeliveryType DeliveryType { get; set; }

        // methods 
        public decimal GetQuotePrice(MegaDeskWebContext context)
        {
            return QuotePrice;
        }

    }
}
