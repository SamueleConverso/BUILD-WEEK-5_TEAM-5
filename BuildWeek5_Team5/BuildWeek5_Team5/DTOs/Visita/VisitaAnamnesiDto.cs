namespace BuildWeek5_Team5.DTOs.Visita
{
    public class VisitaAnamnesiDto
    {
        public int VisitaId { get; set; }
        public DateOnly DataVisita { get; set; }
        public required string Esame { get; set; }
        public required string DescrizioneCura { get; set; }

    }
}
