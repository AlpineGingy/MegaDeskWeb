using System.ComponentModel.DataAnnotations;

namespace MegaDeskWeb.Models
{
    public class Desk
    {

        public int DeskId { get; set; }

        public decimal Width { get; set; }

        public decimal Depth { get; set; }

        [Display(Name = "Number of Drawers")]
        public int NumberOfDrawers { get; set; }

        [Display(Name = "Desktop Material")]
        public int DesktopMaterialId { get; set; }

        // Nav properties

        public DesktopMaterial DesktopMaterial { get; set; }

        public DeskQuote DeskQuote { get; set; }
    }
}
