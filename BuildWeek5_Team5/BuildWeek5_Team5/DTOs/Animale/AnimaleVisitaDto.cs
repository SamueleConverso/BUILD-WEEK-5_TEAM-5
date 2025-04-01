namespace BuildWeek5_Team5.DTOs.Animale
{
    public class AnimaleVisitaDto
    {
        public int? AnimaleId { get; set; }
        public DateOnly? DataRegistrazione { get; set; }

        public string? Nome { get; set; }

        public string? Specie { get; set; }

        public string? Colore { get; set; }
        public DateOnly? DataNascita { get; set; }

        public bool Microchip { get; set; }

        public int? NumeroMicrochip { get; set; }
        public string? NominativoProprietario { get; set; }
    }
}
