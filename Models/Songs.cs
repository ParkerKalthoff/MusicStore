using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Songs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongID { get; set; }

        public required string SongName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public required decimal SongPrice { get; set; }

        public int ArtistID { get; set; }
        public required int GenreID { get; set; }
    }
}
