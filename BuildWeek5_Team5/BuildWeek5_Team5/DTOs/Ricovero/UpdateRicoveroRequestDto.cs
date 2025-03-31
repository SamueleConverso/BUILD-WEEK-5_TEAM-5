using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_Team5.DTOs.Ricovero {
    public class UpdateRicoveroRequestDto {
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
