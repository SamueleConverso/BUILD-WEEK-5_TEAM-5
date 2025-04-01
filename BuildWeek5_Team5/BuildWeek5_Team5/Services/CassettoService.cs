using BuildWeek5_Team5.Data;
using BuildWeek5_Team5.DTOs.Cassetto;
using BuildWeek5_Team5.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildWeek5_Team5.Services
{
    public class CassettoService
    {
        private readonly ApplicationDbContext _context;

        public CassettoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync()
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

        public async Task<bool> Create(Cassetto cassetto)
        {
            try
            {
                _context.Cassetti.Add(cassetto);

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Cassetto>> GetAll()
        {
            try
            {
                return await _context.Cassetti.Include(c => c.Prodotti).ToListAsync();
            }
            catch
            {
                return null!;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var cassetto = await _context.Cassetti.FindAsync(id);

                _context.Cassetti.Remove(cassetto);

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}