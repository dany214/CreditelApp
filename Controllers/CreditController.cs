using CreditelApp.Services;
using CreditelApp.Data;
using CreditelApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditelApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;

        public CreditsController(ApplicationDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCredit(Credit credit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Credits.Add(credit);
            await _context.SaveChangesAsync();

            _ = Task.Run(() =>
                _emailService.SendCreditNotificationAsync(
                    credit.ClientName, credit.Amount, credit.Commercial
                )
            );

            return Ok(credit);
        }

        [HttpGet]
        public async Task<IActionResult> GetCredits([FromQuery] string? clientName, [FromQuery] string? clientId, [FromQuery] string? commercial)
        {
            var query = _context.Credits.AsQueryable();

            if (!string.IsNullOrEmpty(clientName))
                query = query.Where(c => c.ClientName.Contains(clientName));        

            if (!string.IsNullOrEmpty(clientId))
                query = query.Where(c => c.ClientId.Contains(clientId));

            if (!string.IsNullOrEmpty(commercial))
                query = query.Where(c => c.Commercial.Contains(commercial));

            var credits = await query.OrderByDescending(c => c.CreatedAt).ToListAsync();
            return Ok(credits);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCreditById(int id)
        {
            var credit = await _context.Credits.FindAsync(id);
            if (credit == null)
                return NotFound();

            return Ok(credit);
        }
    }
}
