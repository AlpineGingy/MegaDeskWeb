using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MegaDeskWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace MegaDeskWeb.Models
{
    public class DeskQuote
    {
        // constants
        private const decimal BASE_DESK_PRICE = 200.00M;
        private const decimal SURFACE_AREA_COST = 1.00M;
        private const decimal DRAWER_COST = 50.00M;

        // properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ?DeskQuoteId { get; set; }

        [Display(Name = "Customer Name")]
        public string ?CustomerName { get; set; }

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

        public Desk ?Desk { get; set; } 

        public DeliveryType ?DeliveryType { get; set; }

        // methods 
        public decimal GetQuotePrice(MegaDeskWebContext context)
        {
            var Desk = context.Desk.Local.ToList();
            decimal QuotePrice = BASE_DESK_PRICE;
            decimal surfaceArea = Desk[0].Width * Desk[0].Depth;
            if (surfaceArea > 1000)
                QuotePrice += SURFACE_AREA_COST * (surfaceArea - 1000);

            QuotePrice += (Desk[0].NumberOfDrawers * DRAWER_COST);

            //QuotePrice += Desk[0].DesktopMaterial.Cost;


            //if (surfaceArea < 1000)
            //    QuotePrice += DeliveryType.PriceUnder1000;
            //else if (surfaceArea >= 1000 && surfaceArea <= 2000)
            //    QuotePrice += DeliveryType.PriceBetween1000and2000;
            //else
            //    QuotePrice += DeliveryType.PriceOver2000;

            return QuotePrice;
        }

    }
}
