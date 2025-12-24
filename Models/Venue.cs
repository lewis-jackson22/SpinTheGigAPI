using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SpinTheGig.Models
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Address
        public string NameOrNumber { get; set; } = null!;
        public string AddressLine1 { get; set; } = null!;
        public string? AddressLine2 { get; set; }
        public string City { get; set; } = null!;
        public string County { get; set; } = null!;
        public string Postcode { get; set; } = null!;

        // Naviagtion property: One Venue can "have" / "be in" many Epsiodes
        [JsonIgnore] // Prevent circular reference
        public ICollection<Episode> MainVenueEpisodes { get; set; } = new List<Episode>();

        [JsonIgnore] // Prevent circular reference
        public ICollection<Episode> PreGigPubEpisodes { get; set; } = new List<Episode>();
    }
}
