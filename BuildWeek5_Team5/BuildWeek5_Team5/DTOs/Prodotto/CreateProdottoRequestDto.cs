using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_Team5.DTOs.Prodotto
{
    public class CreateProdottoRequestDto
    {
        [Required]
        public string TipoProdotto { get; set; }

        [Required]
        public string NomeProdotto { get; set; }

        [Required]
        public string NomeDitta { get; set; }

        [Required]
        public string RecapitoDitta { get; set; }

        [Required]
        public string IndirizzoDitta { get; set; }

        [Required]
        public string ElencoUsi { get; set; }

        [Required]
        public int CassettoId { get; set; }
    }
}
