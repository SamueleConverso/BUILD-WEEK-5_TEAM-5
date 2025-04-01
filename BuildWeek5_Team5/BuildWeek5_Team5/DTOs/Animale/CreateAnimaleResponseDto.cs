using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_Team5.DTOs.Animale {
    public class CreateAnimaleResponseDto {
        [Required]
        public required string Message {
            get; set;
        }
    }
}
