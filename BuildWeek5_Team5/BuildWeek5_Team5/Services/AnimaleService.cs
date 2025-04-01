using BuildWeek5_Team5.Data;
using BuildWeek5_Team5.DTOs.Animale;
using BuildWeek5_Team5.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildWeek5_Team5.Services {
    public class AnimaleService {
        private ApplicationDbContext _context;

        public AnimaleService(ApplicationDbContext context) {
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

        public async Task<bool> AddAnimaleAsync(Animale animale) {
            try {
                _context.Animali.Add(animale);
                return await SaveAsync();
            } catch (Exception ex) {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Animale>> GetAllAnimaliAsync() {
            var animali = new List<Animale>();

            try {
                animali = await _context.Animali.Include(a => a.Visite).ToListAsync();
                return animali;
            } catch (Exception ex) {
                animali = new List<Animale>();
                Console.WriteLine(ex.Message);
            }

            return animali;
        }

        public async Task<Animale> GetAnimaleByIdAsync(int id) {
            Animale animale = null;

            try {
                animale = await _context.Animali.Include(a => a.Visite).FirstOrDefaultAsync(a => a.AnimaleId == id);
                return animale;
            } catch (Exception ex) {
                animale = null;

                Console.WriteLine(ex.Message);
            }

            return animale;
        }

        public async Task<List<Visita>> GetAnimaleAnamnesiByIdAsync(int id)
        {
            var listVisite = new List<Visita>();

            try
            {
                listVisite = await _context.Visite.Include(v => v.Animale).Where(a => a.AnimaleId == id).OrderByDescending(v => v.DataVisita).ToListAsync();
                return listVisite;
            }
            catch (Exception ex)
            {
                listVisite = null;

                Console.WriteLine(ex.Message);
            }

            return listVisite;
        }

        public async Task<bool> UpdateAnimaleAsync(int id, UpdateAnimaleRequestDto updateAnimaleRequestDto) {
            try {
                var animaleTrovato = await GetAnimaleByIdAsync(id);

                if (animaleTrovato == null) {
                    return false;
                }

                if(animaleTrovato.DataRegistrazione == updateAnimaleRequestDto.DataRegistrazione &&
                animaleTrovato.Nome == updateAnimaleRequestDto.Nome &&
                animaleTrovato.Specie == updateAnimaleRequestDto.Specie &&
                animaleTrovato.Colore == updateAnimaleRequestDto.Colore &&
                animaleTrovato.DataNascita == updateAnimaleRequestDto.DataNascita &&
                animaleTrovato.Microchip == updateAnimaleRequestDto.Microchip &&
                animaleTrovato.NumeroMicrochip == updateAnimaleRequestDto.NumeroMicrochip &&
                animaleTrovato.NominativoProprietario == updateAnimaleRequestDto.NominativoProprietario)
                {
                    return true;
                }

                animaleTrovato.DataRegistrazione = updateAnimaleRequestDto.DataRegistrazione;
                animaleTrovato.Nome = updateAnimaleRequestDto.Nome;
                animaleTrovato.Specie = updateAnimaleRequestDto.Specie;
                animaleTrovato.Colore = updateAnimaleRequestDto.Colore;
                animaleTrovato.DataNascita = updateAnimaleRequestDto.DataNascita;
                animaleTrovato.Microchip = updateAnimaleRequestDto.Microchip;
                animaleTrovato.NumeroMicrochip = updateAnimaleRequestDto.Microchip ? updateAnimaleRequestDto.NumeroMicrochip : null;
                animaleTrovato.NominativoProprietario = updateAnimaleRequestDto.NominativoProprietario;

                return await SaveAsync();
            } catch (Exception ex) {

                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<bool> DeleteAnimaleAsync(int id) {
            try {
                var animale = await GetAnimaleByIdAsync(id);

                if (animale == null) {
                    return false;
                }

                _context.Animali.Remove(animale);

                return await SaveAsync();
            } catch (Exception ex) {

                Console.WriteLine(ex.Message);

                return false;
            }
        }
    }
}
