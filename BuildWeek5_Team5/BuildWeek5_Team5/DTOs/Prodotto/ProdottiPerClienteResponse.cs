using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_Team5.DTOs.Prodotto
{
    public class ProdottiPerClienteResponse
    {
        [Required]
        public string Message { get; set; }
        public List<ProdottoDto> Prodotti { get; set; }
    }
}
