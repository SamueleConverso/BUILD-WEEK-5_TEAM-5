using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_Team5.DTOs.Armadietto
{
    public class CreateArmadiettoResponse
    {
        [Required]
        public string Message { get; set; }
        public int ArmadiettoId { get; set; }
        public int Cassetto { get; set; }
    }
}
