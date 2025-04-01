using BuildWeek5_Team5.Data;
using Microsoft.AspNetCore.Mvc;
using BuildWeek5_Team5.Services;
using BuildWeek5_Team5.DTOs.Armadietto;
using BuildWeek5_Team5.DTOs.Cassetto;
using BuildWeek5_Team5.DTOs.Prodotto;
using Microsoft.AspNetCore.Authorization;

namespace BuildWeek5_Team5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Farmacista")]
    public class ArmadiettoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ArmadiettoService _armadiettoService;

        public ArmadiettoController(ApplicationDbContext context, ArmadiettoService armadiettoService)
        {
            _context = context;
            _armadiettoService = armadiettoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateArmadietto()
        {
            try
            {
                var result = await _armadiettoService.Create();

                return result ? Ok(new { Message = "Armadietto creato con successo!" }) : BadRequest(new { Message = "Si è verificato un errore durante la creazione dell'armadietto" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Si è verificato un errore durante la creazione dell'armadietto" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArmadietti()
        {
            try
            {
                var result = await _armadiettoService.GetArmadietti();
                if (result == null)
                {
                    return BadRequest(new { Message = "Si è verificato un errore durante il recupero degli armadietti" });
                }

                var armadietti = result.Select(r => new ArmadiettoDto
                {
                    ArmadiettoId = r.ArmadiettoId,
                    Cassetti = r.Cassetti.Select(ac => new CassettoDto
                    {
                        CassettoId = ac.CassettoId,
                        NumeroCassetto = ac.NumeroCassetto,
                        Prodotti = ac.Prodotti?.Select(p => new ProdottoCassettoDto
                        {
                            ProdottoId = p.ProdottoId,
                            TipoProdotto = p.TipoProdotto,
                            NomeProdotto = p.NomeProdotto,
                            IndirizzoDitta = p.IndirizzoDitta,
                            NomeDitta = p.NomeDitta,
                            RecapitoDitta = p.RecapitoDitta,
                            ElencoUsi = p.ElencoUsi
                        }).ToList()
                    }).ToList()
                }).ToList();

                return Ok(new { message = "Armadietti recuperati con successo", listaArmadietti = armadietti });
            }
            catch
            {
                return BadRequest(new { Message = "Si è verificato un errore durante il recupero degli armadietti" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var result = await _armadiettoService.Delete(id);

                return result ? Ok(new { message = "Armadietto eliminato con successo" }) : BadRequest(new { message = "Si è verificato un errore durante l'eliminazione dell'armadietto" });
            }
            catch
            {
                return BadRequest(new { message = "Si è verificato un errore durante l'eliminazione dell'armadietto" });
            }
        }
    }
}