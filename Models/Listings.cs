namespace RealEstateWebsite.Models
{
    public class Listings
    {
        public int Id { get; set; }
        public string? houseName { get; set; }
        public int houseCost { get; set; }
        public string? address { get; set; }

        public double squaredMetres { get; set; }

        public string? city { get; set; }

    }
}
