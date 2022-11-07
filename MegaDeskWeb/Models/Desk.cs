using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDeskWeb.Models
{
    public class Desk
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeskId { get; set; }

        [Range(24, 96)]
        public decimal Width { get; set; }

        [Range(12, 48)]
        public decimal Depth { get; set; }

        [Range(0, 7)]
        [Display(Name = "Number of Drawers")]
        public int NumberOfDrawers { get; set; }

        [Display(Name = "Desktop Material")]
        public int DesktopMaterialId { get; set; }

        // Nav properties

        public DesktopMaterial ?DesktopMaterial { get; set; }

        public DeskQuote ?DeskQuote { get; set; }
    }
}
