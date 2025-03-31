using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_Team5.DTOs.Ricovero {
    public class UpdateRicoveroResponseDto {
        [Required]
        public required string Message {
            get; set;
        }
    }
}
