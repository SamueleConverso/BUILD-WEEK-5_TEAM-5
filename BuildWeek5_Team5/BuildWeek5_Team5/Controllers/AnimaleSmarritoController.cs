using BuildWeek5_Team5.Data;
using BuildWeek5_Team5.DTOs.Smarriti;
using BuildWeek5_Team5.DTOs.Visita;
using BuildWeek5_Team5.Models;
using BuildWeek5_Team5.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek5_Team5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Veterinario")]
    public class AnimaleSmarritoController : ControllerBase
    {
        private readonly AnimaleSmarritoService _animaleSmarritoService;
        private readonly ApplicationDbContext _context;

        public AnimaleSmarritoController(AnimaleSmarritoService animaleSmarritoService, ApplicationDbContext context)
        {
            _animaleSmarritoService = animaleSmarritoService;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAnimaleSmarritoDto createAnimaleSmarritoDto)
        {
            var animale = new AnimaleSmarrito()
            {
                Nome = createAnimaleSmarritoDto.Nome,
                Specie = createAnimaleSmarritoDto.Specie,
                Colore = createAnimaleSmarritoDto.Colore,
                Microchip = createAnimaleSmarritoDto.Microchip,
                NumeroMicrochip = createAnimaleSmarritoDto.NumeroMicrochip
            };

            var result = await _animaleSmarritoService.CreateAsync(animale);

            return result ? Ok(new AnimaleSmarritoResponse { Message = "Animale smarrito creato con successo" }) : BadRequest(new AnimaleSmarritoResponse { Message = "Errore durante la creazione dell'animale smarrito" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimali()
        {
            try
            {
                var result = await _animaleSmarritoService.GetAllAsync();

                if (result == null)
                {
                    return BadRequest(new AnimaleSmarritoResponse { Message = "Errore durante il recupero degli animali smarriti" });
                }

                List<AnimaleSmarritoDto> animaleSmarritoDto = result.Select(a => new AnimaleSmarritoDto()
                {
                    AnimaleSmarritoId = a.AnimaleSmarritoId,
                    Nome = a.Nome,
                    Specie = a.Specie,
                    Colore = a.Colore,
                    Microchip = a.Microchip,
                    NumeroMicrochip = a.NumeroMicrochip,
                    Visite = a.Visite?.Select(v => new VisitaAnimaleDto()
                    {
                        VisitaId = v.VisitaId,
                        DescrizioneCura = v.DescrizioneCura,
                        DataVisita = v.DataVisita,
                        Esame = v.Esame
                    }).ToList()
                }).ToList();

                return Ok(new { message = "Animali smarriti recuperati con successo", AnimaliSmarriti = animaleSmarritoDto });
            }
            catch
            {
                return BadRequest(new AnimaleSmarritoResponse { Message = "Errore durante il recupero degli animali smarriti" });
            }
        }

        [HttpPut("/animaleSmarrito")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] CreateAnimaleSmarritoDto createAnimaleSmarritoDto)
        {
            try
            {
                var vecchioAnimale = await _context.AnimaliSmarriti.FindAsync(id);

                if (vecchioAnimale.Nome == createAnimaleSmarritoDto.Nome && vecchioAnimale.Specie == createAnimaleSmarritoDto.Specie && vecchioAnimale.Colore == createAnimaleSmarritoDto.Colore && vecchioAnimale.Microchip == createAnimaleSmarritoDto.Microchip && vecchioAnimale.NumeroMicrochip == createAnimaleSmarritoDto.NumeroMicrochip)
                {
                    return Ok(new AnimaleSmarritoResponse { Message = "Nessuna modifica effettuata." });
                }

                var result = await _animaleSmarritoService.Update(id, createAnimaleSmarritoDto);

                return result ? Ok(new AnimaleSmarritoResponse { Message = "Animale smarrito modificato con successo" }) : BadRequest(new AnimaleSmarritoResponse { Message = "Errore nella modifica dell'animale smarrito." });
            }
            catch
            {
                return BadRequest(new AnimaleSmarritoResponse { Message = "Errore nella modifica dell'animale smarrito." });
            }
        }

        [HttpDelete("/animaleSmarrito")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var result = await _animaleSmarritoService.Delete(id);
                return result ? Ok(new AnimaleSmarritoResponse { Message = "Animale smarrito eliminato con successo" }) : BadRequest(new AnimaleSmarritoResponse { Message = "Errore durante l'eliminazione dell'animale smarrito" });
            }
            catch
            {
                return BadRequest(new AnimaleSmarritoResponse { Message = "Errore durante l'eliminazione dell'animale smarrito" });
            }
        }

        [HttpGet("/animaleSmarrito")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAnimaleSmarritoById([FromQuery] int id)
        {
            try
            {
                var result = await _animaleSmarritoService.GetAnimaleSmarritoById(id);
                if (result == null)
                {
                    return BadRequest(new AnimaleSmarritoResponse { Message = "Errore durante il recupero dell'animale smarrito" });
                }
                var animaleSmarritoDto = new AnimaleSmarritoDto()
                {
                    AnimaleSmarritoId = result.AnimaleSmarritoId,
                    Nome = result.Nome,
                    Specie = result.Specie,
                    Colore = result.Colore,
                    Microchip = result.Microchip,
                    NumeroMicrochip = result.NumeroMicrochip,
                    Visite = result.Visite?.Select(v => new VisitaAnimaleDto()
                    {
                        VisitaId = v.VisitaId,
                        DescrizioneCura = v.DescrizioneCura,
                        DataVisita = v.DataVisita,
                        Esame = v.Esame
                    }).ToList()
                };
                return Ok(new { message = "Animale smarrito recuperato con successo", AnimaleSmarrito = animaleSmarritoDto });
            }
            catch
            {
                return BadRequest(new AnimaleSmarritoResponse { Message = "Errore durante il recupero dell'animale smarrito" });
            }
        }

        [HttpGet("anamnesi")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAnamnesi([FromQuery] int id)
        {
            try
            {
                var visite = await _animaleSmarritoService.GetAnimaleAnamnesiByIdAsync(id);

                if (visite == null)
                {
                    return BadRequest(new VisitaResponseDto
                    {
                        Message = "Errore nel recupero dell'anamnesi"
                    });
                }

                var visiteList = visite.Select(v => new VisitaAnamnesiDto
                {
                    VisitaId = v.VisitaId,
                    DataVisita = v.DataVisita,
                    Esame = v.Esame,
                    DescrizioneCura = v.DescrizioneCura
                }).ToList();

                return Ok(new
                {
                    message = "Anamnesi recuperata con successo",
                    visite = visiteList
                });
            }
            catch
            {
                return BadRequest(new VisitaResponseDto
                {
                    Message = "Errore nel recupero dell'animale"
                });
            }
        }
    }
}
