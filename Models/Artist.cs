using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SpinTheGig.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Naviagtion property: One Artist can "have" / "be in" many Epsiodes
        [JsonIgnore] // Prevent circular reference
        public ICollection<Episode> Episodes { get; set; } = new List<Episode>();

    }
}
