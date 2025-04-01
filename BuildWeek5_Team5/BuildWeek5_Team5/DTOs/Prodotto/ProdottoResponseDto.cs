using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_Team5.DTOs.Prodotto
{
    public class ProdottoResponseDto
    {
        [Required]
        public string Message { get; set; }
    }
}
