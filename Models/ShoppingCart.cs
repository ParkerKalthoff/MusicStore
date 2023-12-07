using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class ShoppingCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string SongName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public required decimal SongPrice { get; set; }
    }
}
