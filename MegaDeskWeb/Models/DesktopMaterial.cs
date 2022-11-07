using System.ComponentModel.DataAnnotations;

namespace MegaDeskWeb.Models
{
    public class DesktopMaterial
    {
        public int DesktopMaterialId { get; set; }

        [Display(Name = "Desktop Material")]
        public string DesktopMaterialName { get; set; }

        public decimal Cost { get; set; }
    }
}
