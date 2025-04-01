using BuildWeek5_Team5.DTOs.Animale;
using BuildWeek5_Team5.DTOs.Smarriti;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_Team5.DTOs.Ricovero {
    public class CreateRicoveroRequestDto {
        [Required]
        public required string Descrizione {
            get; set;
        }

        [Required]
        public required DateOnly DataInizioRicovero {
            get; set;
        }

        public DateOnly? DataFineRicovero {
            get; set;
        }

        public int? AnimaleId {
            get; set;
        }

        public int? AnimaleSmarritoId {
            get; set;
        }
    }
}
