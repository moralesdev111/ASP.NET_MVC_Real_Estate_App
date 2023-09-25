using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateWebsite.Models
{
    public class Listings
    {
        public int Id { get; set; }
        [Display (Name="House")]
        public string? houseName { get; set; }
        [Display (Name ="Cost (€)")]
        [Column(TypeName ="double(15)")]
        public int houseCost { get; set; }
        [Display (Name ="Address")]
        public string? address { get; set; }
        [Display (Name ="Squared Metres")]
        public double squaredMetres { get; set; }
        [Display (Name ="City Location")]
        public string? city { get; set; }

        [Display (Name ="Balcony")]
        public string? hasBalcony { get; set; }

    }
}
