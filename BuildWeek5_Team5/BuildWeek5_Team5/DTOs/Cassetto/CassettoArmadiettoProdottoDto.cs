using BuildWeek5_Team5.DTOs.Armadietto;
using BuildWeek5_Team5.DTOs.Prodotto;

namespace BuildWeek5_Team5.DTOs.Cassetto
{
    public class CassettoArmadiettoProdottoDto
    {
        public required int CassettoId { get; set; }
        public required int NumeroCassetto { get; set; }
        public ArmadiettoProdottoCassettoDto? Armadietto { get; set; }
    }
}
