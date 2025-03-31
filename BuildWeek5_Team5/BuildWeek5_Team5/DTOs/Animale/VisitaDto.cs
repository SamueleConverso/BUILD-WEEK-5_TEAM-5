using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_Team5.DTOs.Animale {
    public class VisitaDto {
        public required int VisitaId {
            get; set;
        }

        [Required]
        public required DateOnly DataVisita {
            get; set;
        }

        [Required]
        public required string Esame {
            get; set;
        }

        [Required]
        public required string DescrizioneCura {
            get; set;
        }
    }
}
