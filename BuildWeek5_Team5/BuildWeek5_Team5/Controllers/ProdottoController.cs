using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BuildWeek5_Team5.DTOs.Farmacia;
using BuildWeek5_Team5.DTOs.Vendite;
using BuildWeek5_Team5.Models;
using BuildWeek5_Team5.Services;
using Microsoft.AspNetCore.Authorization;

namespace BuildWeek5_Team5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdottoController : ControllerBase
    {
        private readonly ProdottoService _prodottoService;
        private readonly ILogger<ProdottoController> _logger;

        public ProdottoController(ProdottoService prodottoService, ILogger<ProdottoController> logger)
        {
            _prodottoService = prodottoService;
            _logger = logger;
        }

        [HttpPost]
        [Authorize(Roles = "Farmacista")]
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
                    ArmadiettoId = newProdotto.ArmadiettoId
                };

                var result = await _prodottoService.CreateProdottoAsync(prodotto);

                return result
                    ? Ok(new CreateProdottoResponse() { Message = "Prodotto creato con successo!" })
                    : BadRequest(new CreateProdottoResponse() { Message = "Si è verificato un errore!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
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
                        new AllProdottiResponseDto() { Message = "Nessun prodotto trovato!", Prodotti = null }
                    );
                }

                var count = result.Count;
                var message = count == 1 ? $"{count} prodotto trovato!" : $"{count} prodotti trovati!";

                return Ok(new AllProdottiResponseDto() { Message = message, Prodotti = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
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
                        new GetProdottoResponseDto() { Message = "Prodotto non trovato!", Prodotto = null }
                    );
                }

                return Ok(
                    new GetProdottoResponseDto() { Message = "Prodotto trovato!", Prodotto = prodotto }
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{prodottoId:int}")]
        [Authorize(Roles = "Farmacista")]
        public async Task<IActionResult> EditProdotto(
            int prodottoId,
            [FromBody] EditProdottoRequestDto editProdotto
        )
        {
            try
            {
                var result = await _prodottoService.EditProdottoAsync(prodottoId, editProdotto);

                return result
                    ? Ok(new EditProdottoResponse() { Message = "Prodotto modificato con successo!" })
                    : BadRequest(new EditProdottoResponse() { Message = "Si è verificato un errore!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{prodottoId:int}")]
        [Authorize(Roles = "Farmacista")]
        public async Task<IActionResult> DeleteProdotto(int prodottoId)
        {
            try
            {
                var result = await _prodottoService.DeleteProdottoAsync(prodottoId);

                return result
                    ? Ok(new DeleteProdottoResponse() { Message = "Prodotto eliminato con successo!" })
                    : BadRequest(new DeleteProdottoResponse() { Message = "Si è verificato un errore!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
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
                        new AllProdottiResponseDto() { Message = "Nessun prodotto trovato!", Prodotti = null }
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
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("posizione/{prodottoId:int}")]
        [Authorize(Roles = "Farmacista")]
        public async Task<IActionResult> GetPosizioneFisica(int prodottoId)
        {
            try
            {
                var posizione = await _prodottoService.GetPosizioneFisicaAsync(prodottoId);

                if (posizione == null)
                {
                    return BadRequest(
                        new PosizioneFisicaResponseDto() { Message = "Prodotto non trovato o posizione non disponibile!", Posizione = null }
                    );
                }

                return Ok(
                    new PosizioneFisicaResponseDto() { Message = "Posizione trovata!", Posizione = posizione }
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
                
        [HttpGet("cliente/{codiceFiscale}")]
        [Authorize(Roles = "Farmacista")]
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
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

    }
}
