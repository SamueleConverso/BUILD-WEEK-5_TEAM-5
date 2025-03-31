using BuildWeek5_Team5.Data;
using BuildWeek5_Team5.Models;

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
    }
}
