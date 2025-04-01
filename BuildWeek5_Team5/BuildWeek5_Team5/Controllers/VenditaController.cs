using BuildWeek5_Team5.Data;
using BuildWeek5_Team5.Models;
using BuildWeek5_Team5.DTOs.Vendite;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuildWeek5_Team5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VenditeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<VenditeController> _logger;

        public VenditeController(ApplicationDbContext context, ILogger<VenditeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        [Authorize(Roles = "Farmacista")]
        public async Task<IActionResult> CreateVendita([FromBody] CreateVenditaRequestDto request)
        {
            try
            {
                var prodotto = await _context.Prodotti.FindAsync(request.ProdottoId);
                if (prodotto == null)
                {
                    return BadRequest(new CreateVenditaResponse
                    {
                        Message = $"Prodotto con ID {request.ProdottoId} non trovato"
                    });
                }

                var vendita = new Vendita
                {
                    DataVendita = request.DataVendita ?? DateOnly.FromDateTime(DateTime.Now),
                    CodiceFiscaleCliente = request.CodiceFiscaleCliente,
                    ProdottoId = request.ProdottoId,
                    RicettaMedica = request.RicettaMedica ?? 0
                };

                _context.Vendite.Add(vendita);
                await _context.SaveChangesAsync();

                return Ok(new CreateVenditaResponse
                {
                    Message = "Vendita registrata con successo!",
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la registrazione della vendita");
                return StatusCode(500, new CreateVenditaResponse
                {
                    Message = "Si è verificato un errore durante la registrazione della vendita"
                });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Farmacista")]
        public async Task<IActionResult> GetAllVendite()
        {
            try
            {
                var vendite = await _context.Vendite
                    .Include(v => v.Prodotto)
                    .Select(v => new VenditaDto
                    {
                        VenditaId = v.VenditaId,
                        DataVendita = v.DataVendita,
                        CodiceFiscaleCliente = v.CodiceFiscaleCliente,
                        ProdottoId = v.ProdottoId,
                        RicettaMedica = v.RicettaMedica > 0 ? v.RicettaMedica : null
                    })
                    .ToListAsync();

                var count = vendite.Count;
                var message = count == 1 ? $"{count} vendita trovata!" : $"{count} vendite trovate!";

                return Ok(new AllVenditeResponse
                {
                    Message = message,
                    Vendite = vendite
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero delle vendite");
                return StatusCode(500, new { Message = "Si è verificato un errore durante il recupero delle vendite" });
            }
        }

        [HttpGet("data/{data}")]
        [Authorize(Roles = "Farmacista")]
        public async Task<IActionResult> GetVenditeByData(string data)
        {
            try
            {
                if (!DateOnly.TryParse(data, out DateOnly parsedDate))
                {
                    return BadRequest(new { Message = "Formato data non valido. Utilizzare il formato YYYY-MM-DD" });
                }

                var vendite = await _context.Vendite
                    .Where(v => v.DataVendita == parsedDate)
                    .Include(v => v.Prodotto)
                    .Select(v => new VenditaDto
                    {
                        VenditaId = v.VenditaId,
                        DataVendita = v.DataVendita,
                        CodiceFiscaleCliente = v.CodiceFiscaleCliente,
                        ProdottoId = v.ProdottoId,
                        RicettaMedica = v.RicettaMedica > 0 ? v.RicettaMedica : null
                    })
                    .ToListAsync();

                var count = vendite.Count;
                var message = count == 1
                    ? $"{count} vendita trovata in data {data}!"
                    : $"{count} vendite trovate in data {data}!";

                return Ok(new AllVenditeResponse
                {
                    Message = message,
                    Vendite = vendite
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero delle vendite per la data {data}");
                return StatusCode(500, new { Message = "Si è verificato un errore durante il recupero delle vendite" });
            }
        }

        [HttpGet("cliente/{codiceFiscale}")]
        [Authorize(Roles = "Farmacista")]
        public async Task<IActionResult> GetVenditeByCliente(string codiceFiscale)
        {
            try
            {
                var vendite = await _context.Vendite
                    .Where(v => v.CodiceFiscaleCliente == codiceFiscale)
                    .Include(v => v.Prodotto)
                    .Select(v => new VenditaDto
                    {
                        VenditaId = v.VenditaId,
                        DataVendita = v.DataVendita,
                        CodiceFiscaleCliente = v.CodiceFiscaleCliente,
                        ProdottoId = v.ProdottoId,
                        RicettaMedica = v.RicettaMedica > 0 ? v.RicettaMedica : null
                    })
                    .ToListAsync();

                var count = vendite.Count;
                var message = count == 1
                    ? $"{count} vendita trovata per il cliente {codiceFiscale}!"
                    : $"{count} vendite trovate per il cliente {codiceFiscale}!";

                return Ok(new AllVenditeResponse
                {
                    Message = message,
                    Vendite = vendite
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero delle vendite per il cliente {codiceFiscale}");
                return StatusCode(500, new { Message = "Si è verificato un errore durante il recupero delle vendite" });
            }
        }
    }
}