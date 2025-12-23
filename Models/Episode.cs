using System.ComponentModel.DataAnnotations;

namespace SpinTheGig.Models
{
    public class Episode
    {
        [Key]
        public int Number { get; set; }
        public int ArtistId { get; set; }
        public int VenueId { get; set; }
        public DateOnly ReleaseDate { get; set; }

        // Navigation properties
        public Artist Artist { get; set; } = null!;
        public Venue Venue { get; set; } = null!;
    }
}
