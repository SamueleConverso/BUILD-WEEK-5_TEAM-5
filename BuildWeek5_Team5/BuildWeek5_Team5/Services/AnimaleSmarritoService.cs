using System.ComponentModel;
using BuildWeek5_Team5.Data;
using BuildWeek5_Team5.DTOs.Smarriti;
using BuildWeek5_Team5.DTOs.Visita;
using BuildWeek5_Team5.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildWeek5_Team5.Services
{
    public class AnimaleSmarritoService
    {
        private readonly ApplicationDbContext _context;

        public AnimaleSmarritoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CreateAsync(AnimaleSmarrito animaleSmarrito)
        {
            try
            {
                _context.AnimaliSmarriti.Add(animaleSmarrito);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }

        }

        public async Task<List<AnimaleSmarrito>> GetAllAsync()
        {
            try
            {
                return await _context.AnimaliSmarriti.ToListAsync();
            }
            catch
            {
                return null!;
            }
        }

        public async Task<AnimaleSmarrito> GetAnimaleSmarritoById(int id)
        {
            try
            {
                var animale = await _context.AnimaliSmarriti.FindAsync(id);
                return animale!;
            }
            catch
            {
                return null!;
            }
        }

        public async Task<List<Visita>> GetAnimaleAnamnesiByIdAsync(int id)
        {
            var listVisite = new List<Visita>();

            try
            {
                listVisite = await _context.Visite.Include(v => v.AnimaleSmarrito).Where(a => a.AnimaleSmarritoId == id).OrderByDescending(v => v.DataVisita).ToListAsync();
                return listVisite;
            }
            catch (Exception ex)
            {
                listVisite = null;

                Console.WriteLine(ex.Message);
            }

            return listVisite;
        }

        public async Task<bool> Update(int id, CreateAnimaleSmarritoDto createAnimaleSmarritoDto)
        {
            try
            {
                var animale = await _context.AnimaliSmarriti.FindAsync(id);

                if(animale == null)
                {
                    return false;
                }

                if (animale.Nome == createAnimaleSmarritoDto.Nome && animale.Specie == createAnimaleSmarritoDto.Specie && animale.Colore == createAnimaleSmarritoDto.Colore && animale.Microchip == createAnimaleSmarritoDto.Microchip && animale.NumeroMicrochip == createAnimaleSmarritoDto.NumeroMicrochip)
                {
                    return true;
                }

                animale.Nome = createAnimaleSmarritoDto.Nome;
                animale.Specie = createAnimaleSmarritoDto.Specie;
                animale.Colore = createAnimaleSmarritoDto.Colore;
                animale.Microchip = createAnimaleSmarritoDto.Microchip;
                animale.NumeroMicrochip = createAnimaleSmarritoDto.NumeroMicrochip;



                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var animale = await _context.AnimaliSmarriti.FindAsync(id);
                if (animale == null)
                {
                    return false;
                }
                _context.AnimaliSmarriti.Remove(animale);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}
