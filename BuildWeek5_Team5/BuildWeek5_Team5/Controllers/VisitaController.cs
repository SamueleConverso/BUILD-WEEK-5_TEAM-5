using BuildWeek5_Team5.Data;
using BuildWeek5_Team5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek5_Team5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitaController : ControllerBase
    {
        private readonly VisitaService _visitaService;
        private readonly ApplicationDbContext _context;
        public VisitaController(VisitaService visitaService, ApplicationDbContext applicationDbContext)
        {
            _visitaService = visitaService;
            _context = applicationDbContext;
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] )
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _visitaService.CreateAsync(visita);
        //        if (result)
        //        {
        //            return Ok();
        //        }
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //    return BadRequest();
        //}
    }
}
