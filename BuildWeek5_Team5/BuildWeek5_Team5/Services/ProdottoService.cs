using BuildWeek5_Team5.Data;
using BuildWeek5_Team5.DTOs.Prodotto;
using BuildWeek5_Team5.DTOs.Vendite;
using BuildWeek5_Team5.DTOs.Cassetto;
using BuildWeek5_Team5.DTOs.Armadietto;
using BuildWeek5_Team5.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildWeek5_Team5.Services
{
    public class ProdottoService
    {
        private readonly ApplicationDbContext _context;

        public ProdottoService(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<ProdottoDto>?> GetAllProdottiAsync()
        {
            try
            {
                var prodotti = await _context.Prodotti
                    .Include(p => p.Cassetto)
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
                    ElencoUsi = p.ElencoUsi
                }).ToList();
            }
            catch
            {
                return null;
            }
        }


        public async Task<ProdottoCassettoArmadiettoDto?> GetProdottoByIdAsync(int prodottoId)
        {
            try
            {
                var prodotto = await _context.Prodotti.Include(p => p.Cassetto).ThenInclude(c => c.Armadietto).FirstOrDefaultAsync(p => p.ProdottoId == prodottoId);

                if (prodotto == null)
                    return null;

                return new ProdottoCassettoArmadiettoDto
                {
                    TipoProdotto = prodotto.TipoProdotto,
                    NomeProdotto = prodotto.NomeProdotto,
                    NomeDitta = prodotto.NomeDitta,
                    RecapitoDitta = prodotto.RecapitoDitta,
                    IndirizzoDitta = prodotto.IndirizzoDitta,
                    ElencoUsi = prodotto.ElencoUsi,
                    Cassetto = new CassettoArmadiettoProdottoDto
                    {
                        CassettoId = prodotto.CassettoId,
                        NumeroCassetto = prodotto.Cassetto.NumeroCassetto,
                        Armadietto = new ArmadiettoProdottoCassettoDto
                        {
                            ArmadiettoId = prodotto.Cassetto.Armadietto.ArmadiettoId
                        }
                    }
                };
            }
            catch
            {
                return null;
            }
        }


        public async Task<bool> CreateProdottoAsync(Prodotto prodotto)
        {
            try
            {
                var cassetto = await _context.Cassetti.FindAsync(prodotto.CassettoId);
                if (cassetto == null)
                    return false;

                _context.Prodotti.Add(prodotto);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }


        public async Task<bool> EditProdottoAsync(int prodottoId, CreateProdottoRequestDto editProdotto)
        {
            try
            {
                var prodotto = await _context.Prodotti.FindAsync(prodottoId);
                if (prodotto == null)
                    return false;

                if (editProdotto.CassettoId != 0 && editProdotto.CassettoId != prodotto.CassettoId)
                {
                    var cassetto = await _context.Cassetti.FindAsync(editProdotto.CassettoId);
                    if (cassetto == null)
                        return false;

                    prodotto.CassettoId = editProdotto.CassettoId;
                }
                
                if(prodotto.TipoProdotto == editProdotto.TipoProdotto && prodotto.NomeProdotto == editProdotto.NomeProdotto && prodotto.NomeDitta == editProdotto.NomeDitta && prodotto.RecapitoDitta == editProdotto.RecapitoDitta && prodotto.IndirizzoDitta == editProdotto.IndirizzoDitta && prodotto.ElencoUsi == editProdotto.ElencoUsi)
                {
                    return true;
                }

                prodotto.TipoProdotto = editProdotto.TipoProdotto;

                prodotto.NomeProdotto = editProdotto.NomeProdotto;

                prodotto.NomeDitta = editProdotto.NomeDitta;

                prodotto.RecapitoDitta = editProdotto.RecapitoDitta;

                prodotto.IndirizzoDitta = editProdotto.IndirizzoDitta;

                prodotto.ElencoUsi = editProdotto.ElencoUsi;



                return await SaveAsync();
            }
            catch
            {
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
                return await SaveAsync();
            }
            catch
            {
                return false;
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
            catch
            {
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
            catch
            {
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
            catch
            {
                return null;
            }
        }
    }
}
