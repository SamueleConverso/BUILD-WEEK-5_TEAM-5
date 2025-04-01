using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildWeek5_Team5.Models {
    [Table("Visite")]
    public class Visita {
        [Key]
        public int VisitaId {
            get; set;
        }

        [Required]
        public DateOnly DataVisita {
            get; set;
        }

        [Required]
        public string Esame {
            get; set;
        }

        [Required]
        public string DescrizioneCura {
            get; set;
        }

        public int? AnimaleId {
            get; set;
        }

        [ForeignKey("AnimaleId")]
        public Animale? Animale {
            get; set;
        }

        public int? AnimaleSmarritoId {
            get; set;
        }

        [ForeignKey("AnimaleSmarritoId")]
        public AnimaleSmarrito? AnimaleSmarrito {
            get; set;
        }
    }
}
