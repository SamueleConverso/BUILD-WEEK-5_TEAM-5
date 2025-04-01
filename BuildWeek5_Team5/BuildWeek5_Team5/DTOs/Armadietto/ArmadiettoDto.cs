using BuildWeek5_Team5.DTOs.Cassetto;
using BuildWeek5_Team5.Models;

namespace BuildWeek5_Team5.DTOs.Armadietto
{
    public class ArmadiettoDto
    {
        public int ArmadiettoId { get; set; }
        public List<CassettoDto>? Cassetti { get; set; }
    }
}
