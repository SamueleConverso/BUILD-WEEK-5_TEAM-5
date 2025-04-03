using System.ComponentModel.DataAnnotations;
using BuildWeek5_Team5.DTOs.Animale;
using BuildWeek5_Team5.DTOs.Smarriti;

namespace BuildWeek5_Team5.DTOs.Ricovero
{
    public class RicoveroDto
    {
        [Required]
        public required int RicoveroId
        {
            get; set;
        }

        [Required]
        public required string Descrizione
        {
            get; set;
        }

        [Required]
        public required DateOnly DataInizioRicovero
        {
            get; set;
        }

        public DateOnly? DataFineRicovero
        {
            get; set;
        }

        public AnimaleDto? Animale
        {
            get; set;
        }

        public AnimaleSmarritoDto? AnimaleSmarrito
        {
            get; set;
        }
    }
}
