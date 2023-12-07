using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models
{
    public class Artists
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArtistID { get; set; }

        public required string ArtistName { get; set; }
        public required int GenreID { get; set; }
    }
}
