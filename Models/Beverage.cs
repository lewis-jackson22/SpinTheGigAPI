using System.Text.Json.Serialization;

namespace SpinTheGig.Models
{
    public class Beverage
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Naviagtion property: One Venue can "have" / "be in" many Epsiodes
        [JsonIgnore] // Prevent circular reference
        public ICollection<Episode> PreGigEpisodes { get; set; } = new List<Episode>();

        [JsonIgnore] // Prevent circular reference
        public ICollection<Episode> MidGigEpisodes { get; set; } = new List<Episode>();
    }
}
