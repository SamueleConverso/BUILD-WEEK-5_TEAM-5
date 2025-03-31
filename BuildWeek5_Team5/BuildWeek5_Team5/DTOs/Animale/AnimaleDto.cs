using System.ComponentModel.DataAnnotations;
using BuildWeek5_Team5.DTOs.Visita;

namespace BuildWeek5_Team5.DTOs.Animale {
    public class AnimaleDto {
        [Required]
        public required int AnimaleId {
            get; set;
        }

        [Required]
        public required DateOnly DataRegistrazione {
            get; set;
        }

        [Required]
        public required string Nome {
            get; set;
        }

        [Required]
        public required string Specie {
            get; set;
        }

        [Required]
        public required string Colore {
            get; set;
        }

        [Required]
        public required DateOnly DataNascita {
            get; set;
        }

        [Required]
        public required bool Microchip {
            get; set;
        }

        public int? NumeroMicrochip {
            get; set;
        }

        [Required]
        public required string NominativoProprietario {
            get; set;
        }

        public ICollection<VisitaAnimaleDto>? Visite {
            get; set;
        }
    }
}
