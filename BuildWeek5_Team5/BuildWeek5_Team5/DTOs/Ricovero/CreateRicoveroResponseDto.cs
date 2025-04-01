using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_Team5.DTOs.Ricovero {
    public class CreateRicoveroResponseDto {
        [Required]
        public required string Message {
            get; set;
        }
    }
}
