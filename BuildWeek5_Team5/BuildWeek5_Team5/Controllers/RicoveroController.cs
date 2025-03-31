using BuildWeek5_Team5.DTOs.Animale;
using BuildWeek5_Team5.DTOs.Ricovero;
using BuildWeek5_Team5.DTOs.Smarriti;
using BuildWeek5_Team5.DTOs.Visita;
using BuildWeek5_Team5.Models;
using BuildWeek5_Team5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek5_Team5.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RicoveroController : ControllerBase {
        private readonly RicoveroService _ricoveroService;

        public RicoveroController(RicoveroService ricoveroService) {
            _ricoveroService = ricoveroService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRicovero([FromBody] CreateRicoveroRequestDto createRicoveroRequestDto) {
            var newRicovero = new Ricovero {
                Descrizione = createRicoveroRequestDto.Descrizione,
                DataInizioRicovero = createRicoveroRequestDto.DataInizioRicovero,
                DataFineRicovero = createRicoveroRequestDto.DataFineRicovero,
                AnimaleId = createRicoveroRequestDto.AnimaleId,
                AnimaleSmarritoId = createRicoveroRequestDto.AnimaleSmarritoId
            };

            var result = await _ricoveroService.AddRicoveroAsync(newRicovero);

            if (!result) {

                return BadRequest(new CreateRicoveroResponseDto {
                    Message = "Errore nell'aggiunta del ricovero"
                });
            }


            return Ok(new CreateRicoveroResponseDto {
                Message = "Ricovero aggiunto con successo"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRicoveri() {
            var ricoveriList = await _ricoveroService.GetAllRicoveriAsync();

            if (ricoveriList == null) {
                return BadRequest(new {
                    message = "Errore nel recupero degli animali"
                });
            }

            if (!ricoveriList.Any()) {
                return NoContent();
            }

            var ricoveriResponse = ricoveriList.Select(r => new RicoveroDto() {
                RicoveroId = r.RicoveroId,
                Descrizione = r.Descrizione,
                DataInizioRicovero = r.DataInizioRicovero,
                DataFineRicovero = r.DataFineRicovero,
                Animale = r.AnimaleId != null ? new AnimaleDto {
                    AnimaleId = r.Animale.AnimaleId,
                    DataRegistrazione = r.Animale.DataRegistrazione,
                    Nome = r.Animale.Nome,
                    Specie = r.Animale.Specie,
                    Colore = r.Animale.Colore,
                    DataNascita = r.Animale.DataNascita,
                    Microchip = r.Animale.Microchip,
                    NumeroMicrochip = r.Animale.NumeroMicrochip,
                    NominativoProprietario = r.Animale.NominativoProprietario,
                    Visite = r.Animale.Visite != null ? r.Animale.Visite.Select(v => new VisitaAnimaleDto {
                        VisitaId = v.VisitaId,
                        DataVisita = v.DataVisita,
                        Esame = v.Esame,
                        DescrizioneCura = v.DescrizioneCura,
                    }).ToList() : null
                } : null,
                AnimaleSmarrito = r.AnimaleSmarritoId != null ? new AnimaleSmarritoDto {
                    AnimaleSmarritoId = r.AnimaleSmarrito.AnimaleSmarritoId,
                    Nome = r.AnimaleSmarrito.Nome,
                    Specie = r.AnimaleSmarrito.Specie,
                    Colore = r.AnimaleSmarrito.Colore,
                    Microchip = r.AnimaleSmarrito.Microchip,
                    NumeroMicrochip = r.AnimaleSmarrito.NumeroMicrochip,
                    Visite = r.AnimaleSmarrito.Visite != null ? r.AnimaleSmarrito.Visite.Select(v => new VisitaAnimaleDto {
                        VisitaId = v.VisitaId,
                        DataVisita = v.DataVisita,
                        Esame = v.Esame,
                        DescrizioneCura = v.DescrizioneCura,
                    }).ToList() : null
                } : null

            });

            return Ok(new {
                message = $"Numero ricoveri trovati: {ricoveriResponse.Count()}",
                ricoveri = ricoveriResponse
            });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRicoveroById(int id) {
            var ricoveroToFind = await _ricoveroService.GetRicoveroByIdAsync(id);

            if (ricoveroToFind == null) {
                return BadRequest(new {
                    message = "Errore nel recupero del ricovero"
                });
            }

            var ricoveroResponse = new RicoveroDto() {
                RicoveroId = ricoveroToFind.RicoveroId,
                Descrizione = ricoveroToFind.Descrizione,
                DataInizioRicovero = ricoveroToFind.DataInizioRicovero,
                DataFineRicovero = ricoveroToFind.DataFineRicovero,
                Animale = ricoveroToFind.AnimaleId != null ? new AnimaleDto {
                    AnimaleId = ricoveroToFind.Animale.AnimaleId,
                    DataRegistrazione = ricoveroToFind.Animale.DataRegistrazione,
                    Nome = ricoveroToFind.Animale.Nome,
                    Specie = ricoveroToFind.Animale.Specie,
                    Colore = ricoveroToFind.Animale.Colore,
                    DataNascita = ricoveroToFind.Animale.DataNascita,
                    Microchip = ricoveroToFind.Animale.Microchip,
                    NumeroMicrochip = ricoveroToFind.Animale.NumeroMicrochip,
                    NominativoProprietario = ricoveroToFind.Animale.NominativoProprietario,
                    Visite = ricoveroToFind.Animale.Visite != null ? ricoveroToFind.Animale.Visite.Select(v => new VisitaAnimaleDto {
                        VisitaId = v.VisitaId,
                        DataVisita = v.DataVisita,
                        Esame = v.Esame,
                        DescrizioneCura = v.DescrizioneCura,
                    }).ToList() : null
                } : null,
                AnimaleSmarrito = ricoveroToFind.AnimaleSmarritoId != null ? new AnimaleSmarritoDto {
                    AnimaleSmarritoId = ricoveroToFind.AnimaleSmarrito.AnimaleSmarritoId,
                    Nome = ricoveroToFind.AnimaleSmarrito.Nome,
                    Specie = ricoveroToFind.AnimaleSmarrito.Specie,
                    Colore = ricoveroToFind.AnimaleSmarrito.Colore,
                    Microchip = ricoveroToFind.AnimaleSmarrito.Microchip,
                    NumeroMicrochip = ricoveroToFind.AnimaleSmarrito.NumeroMicrochip,
                    Visite = ricoveroToFind.AnimaleSmarrito.Visite != null ? ricoveroToFind.AnimaleSmarrito.Visite.Select(v => new VisitaAnimaleDto {
                        VisitaId = v.VisitaId,
                        DataVisita = v.DataVisita,
                        Esame = v.Esame,
                        DescrizioneCura = v.DescrizioneCura,
                    }).ToList() : null
                } : null

            };

            return Ok(new {
                message = "Ricovero trovato con successo",
                animale = ricoveroResponse
            });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRicovero(int id, [FromBody] UpdateRicoveroRequestDto updateRicoveroRequestDto) {
            var result = await _ricoveroService.UpdateRicoveroAsync(id, updateRicoveroRequestDto);

            if (!result) {
                return BadRequest(new UpdateRicoveroResponseDto {
                    Message = "Errore nella modifica del ricovero"
                });
            }

            return Ok(new UpdateRicoveroResponseDto {
                Message = "Ricovero aggiornato con successo"
            });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRicovero(int id) {
            var result = await _ricoveroService.DeleteRicoveroAsync(id);

            if (!result) {
                return BadRequest(new {
                    message = "Errore nella cancellazione del ricovero"
                });
            }

            return Ok(new {
                message = "Ricovero cancellato con successo"
            });
        }
    }
}
