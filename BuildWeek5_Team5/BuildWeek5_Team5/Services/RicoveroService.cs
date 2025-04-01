using BuildWeek5_Team5.Data;
using BuildWeek5_Team5.DTOs.Animale;
using BuildWeek5_Team5.DTOs.Ricovero;
using BuildWeek5_Team5.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildWeek5_Team5.Services {
    public class RicoveroService {
        private ApplicationDbContext _context;

        public RicoveroService(ApplicationDbContext context) {
            _context = context;
        }

        private async Task<bool> SaveAsync() {
            try {
                var rows = await _context.SaveChangesAsync();

                if (rows > 0) {
                    return true;
                } else {
                    return false;
                }
            } catch (Exception ex) {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> AddRicoveroAsync(Ricovero ricovero) {
            try {
                _context.Ricoveri.Add(ricovero);
                return await SaveAsync();
            } catch (Exception ex) {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Ricovero>> GetAllRicoveriAsync() {
            var ricoveri = new List<Ricovero>();

            try {
                ricoveri = await _context.Ricoveri.Include(r => r.Animale).ThenInclude(a => a.Visite).Include(r => r.AnimaleSmarrito).ThenInclude(a => a.Visite).ToListAsync();
                return ricoveri;
            } catch (Exception ex) {
                ricoveri = new List<Ricovero>();
                Console.WriteLine(ex.Message);
            }

            return ricoveri;
        }

        public async Task<Ricovero> GetRicoveroByIdAsync(int id) {
            Ricovero ricovero = null;

            try {
                ricovero = await _context.Ricoveri.Include(r => r.Animale).ThenInclude(a => a.Visite).Include(r => r.AnimaleSmarrito).ThenInclude(a => a.Visite).FirstOrDefaultAsync(r => r.RicoveroId == id);
                return ricovero;
            } catch (Exception ex) {
                ricovero = null;

                Console.WriteLine(ex.Message);
            }

            return ricovero;
        }

        public async Task<AnimaleSmarrito> GetRicoveroByMicrochipAsync(int microchip)
        {
            var animale = new AnimaleSmarrito();

            try
            {
                animale = await _context.AnimaliSmarriti.FirstOrDefaultAsync(a => a.NumeroMicrochip == microchip);
                var ricovero = await _context.Ricoveri.FirstOrDefaultAsync(r => r.AnimaleSmarritoId == animale.AnimaleSmarritoId);

                if(ricovero == null)
                {
                    return null!;
                }

                return animale!;
            }
            catch (Exception ex)
            {
                animale = null;

                Console.WriteLine(ex.Message);
            }

            return animale!;
        }

        public async Task<bool> UpdateRicoveroAsync(int id, UpdateRicoveroRequestDto updateRicoveroRequestDto) {
            try {
                var ricoveroTrovato = await GetRicoveroByIdAsync(id);

                if (ricoveroTrovato == null) {
                    return false;
                }

                ricoveroTrovato.Descrizione = updateRicoveroRequestDto.Descrizione;
                ricoveroTrovato.DataInizioRicovero = updateRicoveroRequestDto.DataInizioRicovero;
                ricoveroTrovato.DataFineRicovero = updateRicoveroRequestDto.DataFineRicovero;
                ricoveroTrovato.AnimaleId = updateRicoveroRequestDto.AnimaleId;
                ricoveroTrovato.AnimaleSmarritoId = updateRicoveroRequestDto.AnimaleSmarritoId;

                return await SaveAsync();
            } catch (Exception ex) {

                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<bool> DeleteRicoveroAsync(int id) {
            try {
                var ricovero = await GetRicoveroByIdAsync(id);

                if (ricovero == null) {
                    return false;
                }

                _context.Ricoveri.Remove(ricovero);

                return await SaveAsync();
            } catch (Exception ex) {

                Console.WriteLine(ex.Message);

                return false;
            }
        }
    }
}
