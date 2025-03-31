using BuildWeek5_Team5.Data;
using BuildWeek5_Team5.Models;
using BuildWeek5_Team5.DTOs.Farmacia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek5_Team5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArmadiettoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ArmadiettoController> _logger;

        public ArmadiettoController(ApplicationDbContext context, ILogger<ArmadiettoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        [Authorize(Roles = "Farmacista")]
        public async Task<IActionResult> CreateArmadietto([FromBody] CreateArmadiettoRequestDto request)
        {
            try
            {
                var armadietto = new Armadietto
                {
                    Cassetto = request.Cassetto
                };

                _context.Armadietti.Add(armadietto);
                await _context.SaveChangesAsync();

                return Ok(new CreateArmadiettoResponse
                {
                    Message = "Armadietto creato con successo!",
                    ArmadiettoId = armadietto.ArmadiettoId,
                    Cassetto = armadietto.Cassetto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione dell'armadietto");
                return StatusCode(500, new { Message = "Si è verificato un errore durante la creazione dell'armadietto" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArmadietti()
        {
            try
            {
                var armadietti = _context.Armadietti.ToList();
                return Ok(new
                {
                    Message = armadietti.Count > 0 ? $"{armadietti.Count} armadietti trovati!" : "Nessun armadietto trovato!",
                    Armadietti = armadietti
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero degli armadietti");
                return StatusCode(500, new { Message = "Si è verificato un errore durante il recupero degli armadietti" });
            }
        }
    }
}