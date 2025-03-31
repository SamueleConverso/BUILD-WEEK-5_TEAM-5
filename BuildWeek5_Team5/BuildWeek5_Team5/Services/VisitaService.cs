using BuildWeek5_Team5.Data;
using BuildWeek5_Team5.DTOs.Smarriti;
using BuildWeek5_Team5.DTOs.Animale;
using BuildWeek5_Team5.DTOs.Visita;
using BuildWeek5_Team5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BuildWeek5_Team5.Services
{
    public class VisitaService
    {
        private readonly ApplicationDbContext _context;

        public VisitaService(ApplicationDbContext context)
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

        public async Task<bool> CreateAsync(Visita visita)
        {
            try
            {
                _context.Visite.Add(visita);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Visita>> GetVisite()
        {
            try
            {
                return await _context.Visite.Include(v => v.Animale).Include(v => v.AnimaleSmarrito).ToListAsync();
            }
            catch
            {
                return null!;
            }
        }

        public async Task<Visita> GetVisitaById(int id)
        {
            try
            {
                var visita = await _context.Visite.Include(v => v.Animale).Include(v => v.AnimaleSmarrito).FirstOrDefaultAsync(x => x.VisitaId == id);
                return visita!;
            }
            catch
            {
                return null!;
            }
        }

        public async Task<bool> Update(int id, CreateVisitaRequestDto createVisitaRequestDto)
        {
            try
            {
                var visita = await _context.Visite.Include(v => v.Animale).Include(v => v.AnimaleSmarrito).FirstOrDefaultAsync(x => x.VisitaId == id);

                if (visita == null)
                {
                    return false;
                }

                visita.DataVisita = createVisitaRequestDto.DataVisita;
                visita.DescrizioneCura = createVisitaRequestDto.DescrizioneCura;
                visita.Esame = createVisitaRequestDto.Esame;
                visita.AnimaleId = createVisitaRequestDto.AnimaleId;
                visita.AnimaleSmarritoId = createVisitaRequestDto.AnimaleSmarritoId;

                if(visita.DataVisita == createVisitaRequestDto.DataVisita && visita.DescrizioneCura == createVisitaRequestDto.DescrizioneCura && visita.Esame == createVisitaRequestDto.Esame && visita.AnimaleId == createVisitaRequestDto.AnimaleId && visita.AnimaleSmarritoId == createVisitaRequestDto.AnimaleSmarritoId)
                {
                    return true;
                }

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
                var visita = await _context.Visite.FindAsync(id);
                if (visita == null)
                {
                    return false;
                }
                _context.Visite.Remove(visita);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}
