using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_Team5.DTOs.Farmacia
{
    public class AllProdottiResponseDto
    {
        [Required]
        public string Message { get; set; }
        public List<ProdottoDto> Prodotti { get; set; }
    }
}
