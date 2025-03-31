using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_Team5.DTOs.Farmacia
{
    public class PosizioneFisicaResponseDto
    {
        [Required]
        public string Message { get; set; }
        public PosizioneFisicaDto Posizione { get; set; }

    }
}
