using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildWeek5_Team5.Models {
    [Table("AnimaliSmarriti")]
    public class AnimaleSmarrito {
        [Key]
        public int AnimaleSmarritoId {
            get; set;
        }

        [Required]
        public string Nome {
            get; set;
        }

        [Required]
        public string Specie {
            get; set;
        }

        [Required]
        public string Colore {
            get; set;
        }

        [Required]
        public bool Microchip {
            get; set;
        }

        public int NumeroMicrochip {
            get; set;
        }

        public ICollection<Visita> Visite {
            get; set;
        }
    }
}
