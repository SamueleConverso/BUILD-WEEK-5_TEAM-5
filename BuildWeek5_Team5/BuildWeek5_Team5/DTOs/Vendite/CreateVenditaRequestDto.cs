namespace BuildWeek5_Team5.DTOs.Vendite
{
    public class CreateVenditaRequestDto
    {
        public DateOnly? DataVendita { get; set; }
        public string CodiceFiscaleCliente { get; set; }
        public int ProdottoId { get; set; }
        public int? RicettaMedica { get; set; }
    }
}
