using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildWeek5_Team5.Models {
    [Table("Prodotti")]
    public class Prodotto {
        [Key]
        public int ProdottoId {
            get; set;
        }

        [Required]
        public string TipoProdotto {
            get; set;
        }

        [Required]
        public string NomeProdotto {
            get; set;
        }

        [Required]
        public string NomeDitta {
            get; set;
        }

        [Required]
        public string RecapitoDitta {
            get; set;
        }

        [Required]
        public string IndirizzoDitta {
            get; set;
        }

        [Required]
        public string ElencoUsi {
            get; set;
        }

        [Required]
        public int CassettoId {
            get; set;
        }

        [ForeignKey("CassettoId")]
        public Cassetto Cassetto {
            get; set;
        }
    }
}
