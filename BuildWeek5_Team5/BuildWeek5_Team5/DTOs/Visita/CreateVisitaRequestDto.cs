namespace BuildWeek5_Team5.DTOs.Visita
{
    public class CreateVisitaRequestDto
    {
        public DateOnly DataVisita { get; set; }

        public required string Esame { get; set; }

        public required string DescrizioneCura { get; set; }

    }
}
