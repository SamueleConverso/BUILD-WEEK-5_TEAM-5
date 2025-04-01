using BuildWeek5_Team5.Data;
using BuildWeek5_Team5.DTOs.Cassetto;
using BuildWeek5_Team5.DTOs.Prodotto;
using BuildWeek5_Team5.Models;
using BuildWeek5_Team5.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek5_Team5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Farmacista")]
    public class CassettoController : ControllerBase
    {
        private readonly CassettoService _cassettoService;
        private readonly ApplicationDbContext _context;

        public CassettoController(CassettoService cassettoService, ApplicationDbContext context)
        {
            _cassettoService = cassettoService;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCassettoDto createCassettoDto)
        {
            try
            {
                var cassetto = new Cassetto()
                {
                    NumeroCassetto = createCassettoDto.NumeroCassetto,
                    ArmadiettoId = createCassettoDto.ArmadiettoId
                };

                var result = await _cassettoService.Create(cassetto);

                return result ? Ok(new CassettoResponseDto { Message = "Cassetto creato con successo" }) : BadRequest(new CassettoResponseDto { Message = "Errore nella creazione del cassetto" });
            }
            catch
            {
                return BadRequest(new CassettoResponseDto { Message = "Errore nella creazione del cassetto" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCassetti()
        {
            try
            {
                var result = await _cassettoService.GetAll();

                if(result == null)
                {
                    return BadRequest(new CassettoResponseDto { Message = "Errore nel recupero dei cassetti" });
                }

                var cassetti = result.Select(c => new CassettoDto()
                {
                    CassettoId = c.CassettoId,
                    NumeroCassetto = c.NumeroCassetto,
                    Prodotti = c.Prodotti?.Select(p => new ProdottoCassettoDto()
                    {
                        ProdottoId = p.ProdottoId,
                        NomeProdotto = p.NomeProdotto,
                        IndirizzoDitta = p.IndirizzoDitta,
                        NomeDitta = p.NomeDitta,
                        RecapitoDitta = p.RecapitoDitta,
                        TipoProdotto = p.TipoProdotto,
                        ElencoUsi = p.ElencoUsi
                    }).ToList()
                });

                return Ok(new { message = "Cassetti trovati.", listaCassetti = cassetti });
            }
            catch 
            {
                return BadRequest(new CassettoResponseDto { Message = "Qualcosa è andato storto." });

            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCassetto([FromQuery] int id)
        {
            try
            {
                var result = await _cassettoService.Delete(id);
                return result ? Ok(new CassettoResponseDto { Message = "Cassetto eliminato con successo" }) : BadRequest(new CassettoResponseDto { Message = "Errore nell'eliminazione del cassetto" });
            }
            catch
            {
                return BadRequest(new CassettoResponseDto { Message = "Errore nell'eliminazione del cassetto" });
            }
        }
    }
}
