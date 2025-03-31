using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_Team5.DTOs.Vendite
{
    public class CreateVenditaResponse
    {
        [Required]
        public string Message { get; set; }
    }
}
