using BuildWeek5_Team5.DTOs.Prodotto;

namespace BuildWeek5_Team5.DTOs.Cassetto
{
    public class CassettoDto
    {
        public required int CassettoId { get; set; }
        public required int NumeroCassetto { get; set; }
        public List<ProdottoCassettoDto>? Prodotti { get; set; }
    }
}
