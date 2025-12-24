using System.ComponentModel.DataAnnotations;

namespace SpinTheGig.Models
{
    public class Episode
    {
        [Key]
        public int Number { get; set; }
        public string Url { get; set; } = null!;
        public decimal TicketPrice { get; set; }

        public int MainArtistId { get; set; }
        public int? SupportingArtistId { get; set; }

        public int VenueId { get; set; }

        public int? PreGigPubId { get; set; }
        public int? PreGigBeverageId { get; set; }
        public decimal? PreGigBeveragePrice { get; set; }

        public int? MidGigBeverageId { get; set; }
        public decimal? MidGigBeveragePrice { get; set; }

        public decimal? BogRating { get; set; }
        public decimal OverallRating { get; set; }

        public DateOnly ReleaseDate { get; set; }


        // Navigation properties
        public Artist MainArtist { get; set; } = null!;
        public Artist? SupportingArtist { get; set; }

        public Venue Venue { get; set; } = null!;
        public Venue? PreGigPub { get; set; }

        public Beverage? PreGigBeverage { get; set; }
        public Beverage? MidGigBeverage { get; set; }
    }
}
