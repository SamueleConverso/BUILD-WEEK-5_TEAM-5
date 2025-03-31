using BuildWeek5_Team5.DTOs.Animale;
using BuildWeek5_Team5.DTOs.Smarriti;

namespace BuildWeek5_Team5.DTOs.Visita
{
    public class VisitaDto
    {
        public int VisitaId { get; set; }
        public DateOnly DataVisita { get; set; }

        public required string Esame { get; set; }

        public required string DescrizioneCura { get; set; }
        public AnimaleVisitaDto Animale { get; set; }
        public SmarritoVisitaDto AnimaleSmarrito { get; set; }
    }
}
