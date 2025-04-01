using BuildWeek5_Team5.Data;
using BuildWeek5_Team5.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildWeek5_Team5.Services
{
    public class ArmadiettoService
    {
        private readonly ApplicationDbContext _context;

        public ArmadiettoService(ApplicationDbContext context)
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

        public async Task<bool> Create()
        {
            try
            {
                var armadietto = new Armadietto() { };

                _context.Armadietti.Add(armadietto);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Armadietto>> GetArmadietti()
        {
            try
            {
                var armadietti = await _context.Armadietti.Include(ac => ac.Cassetti).ThenInclude(c => c.Prodotti).ToListAsync();
                return armadietti;
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
                var armadietto = await _context.Armadietti.FindAsync(id);
                if (armadietto == null)
                {
                    return false;
                }
                _context.Armadietti.Remove(armadietto);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}