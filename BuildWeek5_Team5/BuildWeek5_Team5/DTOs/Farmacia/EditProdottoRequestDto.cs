namespace BuildWeek5_Team5.DTOs.Farmacia
{
    public class EditProdottoRequestDto
    {
        public string TipoProdotto { get; set; }
        public string NomeProdotto { get; set; }
        public string NomeDitta { get; set; }
        public string RecapitoDitta { get; set; }
        public string IndirizzoDitta { get; set; }
        public string ElencoUsi { get; set; }
        public int ArmadiettoId { get; set; }
    }
}
