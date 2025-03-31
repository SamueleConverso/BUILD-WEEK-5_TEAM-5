using BuildWeek5_Team5.Data;
using BuildWeek5_Team5.DTOs.Farmacia;
using BuildWeek5_Team5.DTOs.Vendite;
using BuildWeek5_Team5.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildWeek5_Team5.Services
{
    public class ProdottoService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProdottoService> _logger;

        public ProdottoService(ApplicationDbContext context, ILogger<ProdottoService> logger)
        {
            _context = context;
            _logger = logger;
        }

        private async Task<bool> TrySaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }
        public async Task<List<ProdottoDto>?> GetAllProdottiAsync()
        {
            try
            {
                var prodotti = await _context.Prodotti
                    .Include(p => p.Armadietto)
                    .ToListAsync();

                if (prodotti == null || !prodotti.Any())
                    return null;

                return prodotti.Select(p => new ProdottoDto
                {
                    ProdottoId = p.ProdottoId,
                    TipoProdotto = p.TipoProdotto,
                    NomeProdotto = p.NomeProdotto,
                    NomeDitta = p.NomeDitta,
                    RecapitoDitta = p.RecapitoDitta,
                    IndirizzoDitta = p.IndirizzoDitta,
                    ElencoUsi = p.ElencoUsi,
                    ArmadiettoId = p.ArmadiettoId,
                    Armadietto = new ArmadiettoDto
                    {
                        ArmadiettoId = p.Armadietto.ArmadiettoId,
                        Cassetto = p.Armadietto.Cassetto
                    }
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
        public async Task<ProdottoDto?> GetProdottoByIdAsync(int prodottoId)
        {
            try
            {
                var prodotto = await _context.Prodotti
                    .Include(p => p.Armadietto)
                    .FirstOrDefaultAsync(p => p.ProdottoId == prodottoId);

                if (prodotto == null)
                    return null;

                return new ProdottoDto
                {
                    ProdottoId = prodotto.ProdottoId,
                    TipoProdotto = prodotto.TipoProdotto,
                    NomeProdotto = prodotto.NomeProdotto,
                    NomeDitta = prodotto.NomeDitta,
                    RecapitoDitta = prodotto.RecapitoDitta,
                    IndirizzoDitta = prodotto.IndirizzoDitta,
                    ElencoUsi = prodotto.ElencoUsi,
                    ArmadiettoId = prodotto.ArmadiettoId,
                    Armadietto = new ArmadiettoDto
                    {
                        ArmadiettoId = prodotto.Armadietto.ArmadiettoId,
                        Cassetto = prodotto.Armadietto.Cassetto
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
        public async Task<bool> CreateProdottoAsync(Prodotto prodotto)
        {
            try
            {
                var armadietto = await _context.Armadietti.FindAsync(prodotto.ArmadiettoId);
                if (armadietto == null)
                    return false;

                _context.Prodotti.Add(prodotto);
                return await TrySaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }
        public async Task<bool> EditProdottoAsync(int prodottoId, EditProdottoRequestDto editProdotto)
        {
            try
            {
                var prodotto = await _context.Prodotti.FindAsync(prodottoId);
                if (prodotto == null)
                    return false;

                if (editProdotto.ArmadiettoId != 0 && editProdotto.ArmadiettoId != prodotto.ArmadiettoId)
                {
                    var armadietto = await _context.Armadietti.FindAsync(editProdotto.ArmadiettoId);
                    if (armadietto == null)
                        return false;

                    prodotto.ArmadiettoId = editProdotto.ArmadiettoId;
                }

                if (!string.IsNullOrEmpty(editProdotto.TipoProdotto))
                    prodotto.TipoProdotto = editProdotto.TipoProdotto;

                if (!string.IsNullOrEmpty(editProdotto.NomeProdotto))
                    prodotto.NomeProdotto = editProdotto.NomeProdotto;

                if (!string.IsNullOrEmpty(editProdotto.NomeDitta))
                    prodotto.NomeDitta = editProdotto.NomeDitta;

                if (!string.IsNullOrEmpty(editProdotto.RecapitoDitta))
                    prodotto.RecapitoDitta = editProdotto.RecapitoDitta;

                if (!string.IsNullOrEmpty(editProdotto.IndirizzoDitta))
                    prodotto.IndirizzoDitta = editProdotto.IndirizzoDitta;

                if (!string.IsNullOrEmpty(editProdotto.ElencoUsi))
                    prodotto.ElencoUsi = editProdotto.ElencoUsi;

                return await TrySaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }
        public async Task<bool> DeleteProdottoAsync(int prodottoId)
        {
            try
            {
                var prodotto = await _context.Prodotti.FindAsync(prodottoId);
                if (prodotto == null)
                    return false;

                var hasVendite = await _context.Vendite.AnyAsync(v => v.ProdottoId == prodottoId);
                if (hasVendite)
                    return false;

                _context.Prodotti.Remove(prodotto);
                return await TrySaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }
        public async Task<PosizioneFisicaDto?> GetPosizioneFisicaAsync(int prodottoId)
        {
            try
            {
                var result = await _context.Prodotti
                    .Where(p => p.ProdottoId == prodottoId)
                    .Join(_context.Armadietti,
                        prodotto => prodotto.ArmadiettoId,
                        armadietto => armadietto.ArmadiettoId,
                        (prodotto, armadietto) => new PosizioneFisicaDto
                        {
                            ProdottoId = prodotto.ProdottoId,
                            NomeProdotto = prodotto.NomeProdotto,
                            ArmadiettoId = armadietto.ArmadiettoId,
                            Cassetto = armadietto.Cassetto
                        })
                    .FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
        public async Task<List<VenditaDto>?> GetVenditeByDataAsync(DateOnly data)
        {
            try
            {
                var vendite = await _context.Vendite
                    .Where(v => v.DataVendita == data)
                    .Join(_context.Prodotti,
                        vendita => vendita.ProdottoId,
                        prodotto => prodotto.ProdottoId,
                        (vendita, prodotto) => new VenditaDto
                        {
                            VenditaId = vendita.VenditaId,
                            DataVendita = vendita.DataVendita,
                            CodiceFiscaleCliente = vendita.CodiceFiscaleCliente,
                            ProdottoId = vendita.ProdottoId,
                            RicettaMedica = vendita.RicettaMedica > 0 ? vendita.RicettaMedica : null
                        })
                    .ToListAsync();

                return vendite.Any() ? vendite : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
        public async Task<List<ProdottoListDto>?> GetProdottiByCodiceFiscaleAsync(string codiceFiscale)
        {
            try
            {
                var prodotti = await _context.Vendite
                    .Where(v => v.CodiceFiscaleCliente == codiceFiscale)
                    .Join(_context.Prodotti,
                        vendita => vendita.ProdottoId,
                        prodotto => prodotto.ProdottoId,
                        (vendita, prodotto) => new ProdottoListDto
                        {
                            ProdottoId = prodotto.ProdottoId,
                            TipoProdotto = prodotto.TipoProdotto,
                            NomeProdotto = prodotto.NomeProdotto,
                            NomeDitta = prodotto.NomeDitta
                        })
                    .Distinct()
                    .ToListAsync();

                return prodotti.Any() ? prodotti : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
        public async Task<List<ProdottoListDto>?> SearchProdottiAsync(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    var allProdotti = await _context.Prodotti
                        .Select(p => new ProdottoListDto
                        {
                            ProdottoId = p.ProdottoId,
                            TipoProdotto = p.TipoProdotto,
                            NomeProdotto = p.NomeProdotto,
                            NomeDitta = p.NomeDitta
                        })
                        .ToListAsync();

                    return allProdotti.Any() ? allProdotti : null;
                }

                searchTerm = searchTerm.ToLower();

                var prodotti = await _context.Prodotti
                    .Where(p => p.NomeProdotto.ToLower().Contains(searchTerm) ||
                               p.TipoProdotto.ToLower().Contains(searchTerm))
                    .Select(p => new ProdottoListDto
                    {
                        ProdottoId = p.ProdottoId,
                        TipoProdotto = p.TipoProdotto,
                        NomeProdotto = p.NomeProdotto,
                        NomeDitta = p.NomeDitta
                    })
                    .ToListAsync();

                return prodotti.Any() ? prodotti : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
    }
}
