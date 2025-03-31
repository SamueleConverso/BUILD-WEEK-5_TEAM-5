using BuildWeek5_Team5.DTOs.Animale;
using BuildWeek5_Team5.DTOs.Visita;
using BuildWeek5_Team5.Models;
using BuildWeek5_Team5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek5_Team5.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AnimaleController : ControllerBase {
        private readonly AnimaleService _animaleService;

        public AnimaleController(AnimaleService animaleService) {
            _animaleService = animaleService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimale([FromBody] CreateAnimaleRequestDto createAnimaleRequestDto) {
            var newAnimale = new Animale {
                DataRegistrazione = createAnimaleRequestDto.DataRegistrazione,
                Nome = createAnimaleRequestDto.Nome,
                Specie = createAnimaleRequestDto.Specie,
                Colore = createAnimaleRequestDto.Colore,
                DataNascita = createAnimaleRequestDto.DataNascita,
                Microchip = createAnimaleRequestDto.Microchip,
                NumeroMicrochip = createAnimaleRequestDto.Microchip ? createAnimaleRequestDto?.NumeroMicrochip : null,
                NominativoProprietario = createAnimaleRequestDto.NominativoProprietario
            };

            var result = await _animaleService.AddAnimaleAsync(newAnimale);

            if (!result) {

                return BadRequest(new CreateAnimaleResponseDto {
                    Message = "Errore nell'aggiunta dell'animale"
                });
            }


            return Ok(new CreateAnimaleResponseDto {
                Message = "Animale aggiunto con successo"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimali() {
            var animaliList = await _animaleService.GetAllAnimaliAsync();

            if (animaliList == null) {
                return BadRequest(new {
                    message = "Errore nel recupero degli animali"
                });
            }

            if (!animaliList.Any()) {
                return NoContent();
            }

            var animaliResponse = animaliList.Select(a => new AnimaleDto() {
                AnimaleId = a.AnimaleId,
                DataRegistrazione = a.DataRegistrazione,
                Nome = a.Nome,
                Specie = a.Specie,
                Colore = a.Colore,
                DataNascita = a.DataNascita,
                Microchip = a.Microchip,
                NumeroMicrochip = a.NumeroMicrochip,
                NominativoProprietario = a.NominativoProprietario,
                Visite = a.Visite != null ? a.Visite.Select(v => new VisitaAnimaleDto {
                    VisitaId = v.VisitaId,
                    DataVisita = v.DataVisita,
                    Esame = v.Esame,
                    DescrizioneCura = v.DescrizioneCura,

                }).ToList() : null
            });

            return Ok(new {
                message = $"Numero animali trovati: {animaliResponse.Count()}",
                animali = animaliResponse
            });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAnimaleById(int id) {
            var animaleToFind = await _animaleService.GetAnimaleByIdAsync(id);

            if (animaleToFind == null) {
                return BadRequest(new {
                    message = "Errore nel recupero dell'animale"
                });
            }

            var animaleResponse = new AnimaleDto {
                AnimaleId = animaleToFind.AnimaleId,
                DataRegistrazione = animaleToFind.DataRegistrazione,
                Nome = animaleToFind.Nome,
                Specie = animaleToFind.Specie,
                Colore = animaleToFind.Colore,
                DataNascita = animaleToFind.DataNascita,
                Microchip = animaleToFind.Microchip,
                NumeroMicrochip = animaleToFind.NumeroMicrochip,
                NominativoProprietario = animaleToFind.NominativoProprietario,
                Visite = animaleToFind.Visite != null ? animaleToFind.Visite.Select(v => new VisitaAnimaleDto {
                    VisitaId = v.VisitaId,
                    DataVisita = v.DataVisita,
                    Esame = v.Esame,
                    DescrizioneCura = v.DescrizioneCura,
                }).ToList() : null
            };

            return Ok(new {
                message = "Animale trovato con successo",
                animale = animaleResponse
            });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateArtista(int id, [FromBody] UpdateAnimaleRequestDto updateAnimaleRequestDto) {
            var result = await _animaleService.UpdateAnimaleAsync(id, updateAnimaleRequestDto);

            if (!result) {
                return BadRequest(new UpdateAnimaleResponseDto {
                    Message = "Errore nella modifica dell'animale"
                });
            }

            return Ok(new UpdateAnimaleResponseDto {
                Message = "Animale aggiornato con successo"
            });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAnimale(int id) {
            var result = await _animaleService.DeleteAnimaleAsync(id);

            if (!result) {
                return BadRequest(new {
                    message = "Errore nella cancellazione dell'animale"
                });
            }

            return Ok(new {
                message = "Animale cancellato con successo"
            });
        }
    }
}
