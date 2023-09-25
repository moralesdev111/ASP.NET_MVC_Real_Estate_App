using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateWebsite.Models
{
    public class Listings
    {
        public int Id { get; set; }

        [StringLength(65,MinimumLength=3)]
        [Required]
        [Display (Name="House")]
        public string? houseName { get; set; }

        [Display (Name ="Cost (€)")]
        [Range(1,1000000)]
        [DataType(DataType.Currency)]
        public int houseCost { get; set; }

        [Display (Name ="Address")]
        [Required]
        public string? address { get; set; }

        [Range (0,99)]
        [Required]
        [Display (Name ="Squared Metres")]
        public double squaredMetres { get; set; }

        [Required]
        [Display (Name ="City Location")]
        public string? city { get; set; }

        [Display (Name ="Balcony")]
        [StringLength(5,MinimumLength =1)]
        public string? hasBalcony { get; set; }

    }
}
