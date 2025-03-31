using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_Team5.DTOs.Vendite
{
    public class VenditePerDataResponseDto
    {
        [Required]
        public string Message { get; set; }
        public List<VenditaDto> Vendite { get; set; }
    }
}
