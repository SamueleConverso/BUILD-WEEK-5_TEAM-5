using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BuildWeek5_Team5.Models;
using BuildWeek5_Team5.Services;
using BuildWeek5_Team5.DTOs.Prodotto;
using BuildWeek5_Team5.Data;
using Microsoft.AspNetCore.Authorization;

namespace BuildWeek5_Team5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Farmacista")]
    public class ProdottoController : ControllerBase
    {
        private readonly ProdottoService _prodottoService;
        private readonly ApplicationDbContext _context;

        public ProdottoController(ProdottoService prodottoService, ApplicationDbContext context)
        {
            _prodottoService = prodottoService;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProdotto([FromBody] CreateProdottoRequestDto newProdotto)
        {
            try
            {
                var prodotto = new Prodotto()
                {
                    TipoProdotto = newProdotto.TipoProdotto,
                    NomeProdotto = newProdotto.NomeProdotto,
                    NomeDitta = newProdotto.NomeDitta,
                    RecapitoDitta = newProdotto.RecapitoDitta,
                    IndirizzoDitta = newProdotto.IndirizzoDitta,
                    ElencoUsi = newProdotto.ElencoUsi,
                    CassettoId = newProdotto.CassettoId
                };

                var result = await _prodottoService.CreateProdottoAsync(prodotto);

                return result
                    ? Ok(new ProdottoResponseDto() { Message = "Prodotto creato con successo!" })
                    : BadRequest(new ProdottoResponseDto() { Message = "Si è verificato un errore!" });
            }
            catch
            {
                return BadRequest(new ProdottoResponseDto
                {
                    Message = "Si è verificato un errore!"
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProdotti()
        {
            try
            {
                var result = await _prodottoService.GetAllProdottiAsync();

                if (result == null)
                {
                    return Ok(
                        new ProdottoResponseDto() { Message = "Nessun prodotto trovato!" }
                    );
                }

                var count = result.Count;
                var message = count == 1 ? $"{count} prodotto trovato!" : $"{count} prodotti trovati!";

                return Ok(new AllProdottiResponseDto() { Message = message, Prodotti = result });
            }
            catch
            {
                return BadRequest(new ProdottoResponseDto { Message = "Qualcosa è andato storto." });
            }
        }

        [HttpGet("{prodottoId:int}")]
        public async Task<IActionResult> GetProdotto(int prodottoId)
        {
            try
            {
                var prodotto = await _prodottoService.GetProdottoByIdAsync(prodottoId);

                if (prodotto == null)
                {
                    return BadRequest(
                        new ProdottoResponseDto { Message = "Prodotto non trovato!"}
                    );
                }

                return Ok(
                    new { message = "Prodotto trovato!", Prodotto = prodotto }
                );
            }
            catch
            {
                return BadRequest(new ProdottoResponseDto { Message = "Qualcosa è andato storto." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditProdotto([FromQuery] int prodottoId, [FromBody] CreateProdottoRequestDto editProdotto)
        {
            try
            {
                var vecchioProdotto = await _context.Prodotti.FindAsync(prodottoId);

                if (vecchioProdotto == null)
                {
                    return BadRequest(new ProdottoResponseDto
                    {
                        Message = "Nessun prodotto trovato."
                    });
                }

                if (vecchioProdotto.TipoProdotto == editProdotto.TipoProdotto && vecchioProdotto.NomeProdotto == editProdotto.NomeProdotto && vecchioProdotto.NomeDitta == editProdotto.NomeDitta && vecchioProdotto.RecapitoDitta == editProdotto.RecapitoDitta && vecchioProdotto.IndirizzoDitta == editProdotto.IndirizzoDitta && vecchioProdotto.ElencoUsi == editProdotto.ElencoUsi)
                {
                    return Ok(new ProdottoResponseDto
                    {
                        Message = "Nessuna modifica effettuata"
                    });
                }

                var result = await _prodottoService.EditProdottoAsync(prodottoId, editProdotto);

                return result
                    ? Ok(new ProdottoResponseDto() { Message = "Prodotto modificato con successo!" })
                    : BadRequest(new ProdottoResponseDto() { Message = "Si è verificato un errore!" });
            }
            catch
            {
                return BadRequest(new ProdottoResponseDto { Message = "Qualcosa è andato storto." });

            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProdotto([FromQuery] int prodottoId)
        {
            try
            {
                var result = await _prodottoService.DeleteProdottoAsync(prodottoId);

                return result
                    ? Ok(new ProdottoResponseDto() { Message = "Prodotto eliminato con successo!" })
                    : BadRequest(new ProdottoResponseDto() { Message = "Si è verificato un errore!" });
            }
            catch
            {
                return BadRequest(new ProdottoResponseDto { Message = "Qualcosa è andato storto." });
            }
        }

        [HttpGet("ricerca")]
        public async Task<IActionResult> SearchProdotti([FromQuery] string termine)
        {
            try
            {
                var prodotti = await _prodottoService.SearchProdottiAsync(termine);

                if (prodotti == null)
                {
                    return Ok(
                        new ProdottoResponseDto() { Message = "Nessun prodotto trovato!"}
                    );
                }

                var count = prodotti.Count;
                var message = count == 1 ? $"{count} prodotto trovato!" : $"{count} prodotti trovati!";

                return Ok(new AllProdottiResponseDto()
                {
                    Message = message,
                    Prodotti = prodotti.Select(p => new ProdottoDto
                    {
                        ProdottoId = p.ProdottoId,
                        TipoProdotto = p.TipoProdotto,
                        NomeProdotto = p.NomeProdotto,
                        NomeDitta = p.NomeDitta
                    }).ToList()
                });
            }
            catch
            {
                return BadRequest(new ProdottoResponseDto { Message = "Qualcosa è andato storto." });
            }
        }


        [HttpGet("cliente/{codiceFiscale}")]
        public async Task<IActionResult> GetProdottiByCliente(string codiceFiscale)
        {
            try
            {
                var prodotti = await _prodottoService.GetProdottiByCodiceFiscaleAsync(codiceFiscale);

                if (prodotti == null)
                {
                    return Ok(
                        new ProdottiPerClienteResponse() { Message = $"Nessun prodotto trovato per il cliente {codiceFiscale}!", Prodotti = null }
                    );
                }

                var count = prodotti.Count;
                var message = count == 1
                    ? $"{count} prodotto trovato per il cliente {codiceFiscale}!"
                    : $"{count} prodotti trovati per il cliente {codiceFiscale}!";

                return Ok(new ProdottiPerClienteResponse()
                {
                    Message = message,
                    Prodotti = prodotti.Select(p => new ProdottoDto
                    {
                        ProdottoId = p.ProdottoId,
                        TipoProdotto = p.TipoProdotto,
                        NomeProdotto = p.NomeProdotto,
                        NomeDitta = p.NomeDitta
                    }).ToList()
                });
            }
            catch
            {
                return BadRequest(new ProdottoResponseDto { Message = "Qualcosa è andato storto." });
            }
        }

    }
}
