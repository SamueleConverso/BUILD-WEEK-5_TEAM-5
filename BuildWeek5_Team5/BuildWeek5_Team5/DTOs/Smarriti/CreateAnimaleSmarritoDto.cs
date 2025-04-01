namespace BuildWeek5_Team5.DTOs.Smarriti
{
    public class CreateAnimaleSmarritoDto
    {
        public required string Nome { get; set; }

        public required string Specie { get; set; }

        public required string Colore { get; set; }

        public required bool Microchip { get; set; }

        public int? NumeroMicrochip { get; set; }
    }
}
