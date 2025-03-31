using BuildWeek5_Team5.DTOs.Visita;

namespace BuildWeek5_Team5.DTOs.Smarriti
{
    public class AnimaleSmarritoDto
    {
        public int AnimaleSmarritoId { get; set; }

        public required string Nome { get; set; }

        public required string Specie { get; set; }

        public required string Colore { get; set; }

        public required bool Microchip { get; set; }

        public int? NumeroMicrochip { get; set; }

        public List<VisitaAnimaleDto>? Visite { get; set; }
    }
}
