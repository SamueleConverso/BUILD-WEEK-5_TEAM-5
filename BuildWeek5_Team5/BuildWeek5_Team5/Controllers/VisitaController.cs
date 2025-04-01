using BuildWeek5_Team5.Data;
using BuildWeek5_Team5.DTOs.Visita;
using BuildWeek5_Team5.DTOs.Animale;
using BuildWeek5_Team5.DTOs.Smarriti;
using BuildWeek5_Team5.Models;
using BuildWeek5_Team5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;

namespace BuildWeek5_Team5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Veterinario")]
    public class VisitaController : ControllerBase
    {
        private readonly VisitaService _visitaService;
        private readonly ApplicationDbContext _context;
        public VisitaController(VisitaService visitaService, ApplicationDbContext applicationDbContext)
        {
            _visitaService = visitaService;
            _context = applicationDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVisitaRequestDto createVisitaRequestDto)
        {
            try
            {
                var visita = new Visita()
                {
                    DataVisita = createVisitaRequestDto.DataVisita,
                    Esame = createVisitaRequestDto.Esame,
                    DescrizioneCura = createVisitaRequestDto.DescrizioneCura,
                    AnimaleId = createVisitaRequestDto?.AnimaleId,
                    AnimaleSmarritoId = createVisitaRequestDto?.AnimaleSmarritoId
                };
                var result = await _visitaService.CreateAsync(visita);
                return result ? Ok(new VisitaResponseDto { Message = "Visita creata con successo." }) : BadRequest(new VisitaResponseDto { Message = "Errore nella creazione della visita." });

            }
            catch
            {
                return BadRequest(new VisitaResponseDto { Message = "Qualcosa è andato storto." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetVisite()
        {
            try
            {
                var result = await _visitaService.GetVisite();

                if (result == null)
                {
                    return BadRequest(new VisitaResponseDto { Message = "Nessuna visita trovata." });
                }

                List<VisitaDto> visite = result.Select(v => new VisitaDto
                {
                    VisitaId = v.VisitaId,
                    DataVisita = v.DataVisita,
                    Esame = v.Esame,
                    DescrizioneCura = v.DescrizioneCura,
                    Animale = v.Animale != null ? new AnimaleVisitaDto()
                    {
                        AnimaleId = v?.AnimaleId,
                        Nome = v?.Animale.Nome,
                        Specie = v?.Animale.Specie,
                        Colore = v?.Animale.Colore,
                        DataNascita = v?.Animale.DataNascita,
                        Microchip = v.Animale.Microchip,
                        NumeroMicrochip = v?.Animale.NumeroMicrochip,
                        NominativoProprietario = v?.Animale.NominativoProprietario
                    } : null,
                    AnimaleSmarrito = v.AnimaleSmarrito != null ?
                    new SmarritoVisitaDto()
                    {
                        AnimaleSmarritoId = v?.AnimaleSmarritoId,
                        Nome = v?.AnimaleSmarrito.Nome,
                        Specie = v?.AnimaleSmarrito.Specie,
                        Colore = v?.AnimaleSmarrito.Colore,
                        Microchip = v.AnimaleSmarrito.Microchip,
                        NumeroMicrochip = v?.AnimaleSmarrito.NumeroMicrochip,
                    } : null
                }).ToList();

                return Ok(new { message = "Visite trovate.", listaVisite = visite });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("visita")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] CreateVisitaRequestDto createVisitaRequestDto)
        {
            try
            {
                var vecchiaVisita = await _context.Visite.FindAsync(id);
                if (vecchiaVisita.DataVisita == createVisitaRequestDto.DataVisita && vecchiaVisita.DescrizioneCura == createVisitaRequestDto.DescrizioneCura && vecchiaVisita.Esame == createVisitaRequestDto.Esame && vecchiaVisita.AnimaleId == createVisitaRequestDto.AnimaleId && vecchiaVisita.AnimaleSmarritoId == createVisitaRequestDto.AnimaleSmarritoId)
                {
                    return Ok(new VisitaResponseDto { Message = "Nessuna modifica effettuata." });
                }
                var result = await _visitaService.Update(id, createVisitaRequestDto);

                return result ? Ok(new VisitaResponseDto { Message = "Visita modificata con successo." }) : BadRequest(new VisitaResponseDto { Message = "Errore nella modifica della visita." });
            }
            catch
            {
                return BadRequest(new VisitaResponseDto { Message = "Qualcosa è andato storto." });
            }
        }

        [HttpDelete("visita")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var result = await _visitaService.Delete(id);
                return result ? Ok(new VisitaResponseDto { Message = "Visita eliminata con successo." }) : BadRequest(new VisitaResponseDto { Message = "Errore nell'eliminazione della visita." });
            }
            catch
            {
                return BadRequest(new VisitaResponseDto { Message = "Qualcosa è andato storto." });
            }
        }
    }
}