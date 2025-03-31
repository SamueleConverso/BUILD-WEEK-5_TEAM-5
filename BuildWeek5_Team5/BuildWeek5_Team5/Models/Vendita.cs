using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildWeek5_Team5.Models {
    [Table("Vendite")]
    public class Vendita {
        [Key]
        public int VenditaId {
            get; set;
        }

        [Required]
        public DateOnly DataVendita {
            get; set;
        }

        [Required]
        public string CodiceFiscaleCliente {
            get; set;
        }

        [Required]
        public int ProdottoId {
            get; set;
        }

        [ForeignKey("ProdottoId")]
        public Prodotto Prodotto {
            get; set;
        }

        public int RicettaMedica {
            get; set;
        }
    }
}
