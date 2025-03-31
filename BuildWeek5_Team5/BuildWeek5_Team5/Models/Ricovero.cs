using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildWeek5_Team5.Models {
    [Table("Ricoveri")]
    public class Ricovero {
        [Key]
        public int RicoveroId {
            get; set;
        }

        [Required]
        public string Descrizione {
            get; set;
        }

        [Required]
        public DateOnly DataInizioRicovero {
            get; set;
        }

        public DateOnly DataFineRicovero {
            get; set;
        }

        public int AnimaleId {
            get; set;
        }

        [ForeignKey("AnimaleId")]
        public Animale Animale {
            get; set;
        }

        public int AnimaleSmarritoId {
            get; set;
        }

        [ForeignKey("AnimaleSmarritoId")]
        public AnimaleSmarrito AnimaleSmarrito {
            get; set;
        }
    }
}
