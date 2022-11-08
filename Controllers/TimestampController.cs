using Microsoft.AspNetCore.Mvc;
using test_csharp.Data;
using test_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace test_csharp.Controllers
{

    [ApiController]
    public class TimestampController : ControllerBase
    {
        private readonly TicketsContext _context;

        public TimestampController(TicketsContext context)
        {
            _context = context;
        }


        [HttpGet("/timestamps")]
        public async Task<IActionResult> Get()
        {

            return Ok(new
            {
                data = 3,
                date = DateTime.Now.ToString("dd-MM-yyyy"),
                time = DateTime.Now.ToString("HH:mm:ss"),
                lists = new List<string>() { "Data", "Architech", "vck" }
            });
        }

        [HttpGet("/tickets")]
        public async Task<List<Tickets>> GetTickets()
        {
            return await _context.tickets.ToListAsync();
        }

        [HttpGet("/tickets/{id}")]
        public async Task<ActionResult> GetTicket(int id)
        {
            var ticket = await _context.tickets.FindAsync(id);

            if (ticket is null)
                return new NotFoundResult();

            return Ok(ticket);
        }

        [HttpPost("/tickets")]
        public async Task<ActionResult> Create([FromBody] Tickets tickets)
        {
            if (tickets is null)
                return new BadRequestObjectResult("Body is empty or null");

            await _context.tickets.AddAsync(tickets);
            await _context.SaveChangesAsync();

            return new OkObjectResult(tickets);
        }
    }
}