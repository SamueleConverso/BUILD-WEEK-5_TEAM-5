using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildWeek5_Team5.Models
{
    [Table("Cassetti")]
    public class Cassetto
    {
        [Key]
        public int CassettoId { get; set; }

        [Required]
        public required int NumeroCassetto { get; set; }

        [Required]
        public required int ArmadiettoId { get; set; }

        [ForeignKey("ArmadiettoId")]
        public Armadietto Armadietto { get; set; }

        public ICollection<Prodotto>? Prodotti
        {
            get; set;
        }
    }
}
