using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TracePointAPI.Data;
using TracePointAPI.Models;
using Dapper;
using MySqlConnector;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TracePointAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestigationsController : ControllerBase
    {
        private readonly TracePointDbContext _context;
        private readonly IConfiguration _configuration;

        public InvestigationsController(
            TracePointDbContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        // GET: api/<InvestigationsController>
        [HttpGet]
        public async Task<IActionResult> GetAllInvestigations()
        {
            var investigations = await _context.Investigations.ToListAsync();

            return Ok(investigations);
        }


        // GET api/<InvestigationsController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetInvestigationById(int id)
        {
            var investigation = await _context.Investigations
                .FirstOrDefaultAsync(i => i.InvestigationID == id);

            if (investigation == null)
            {
                return NotFound("Investigation not found.");
            }

            return Ok(investigation);
        }
        // POST api/<InvestigationsController>
        [HttpPost]
        public async Task<IActionResult> CreateInvestigation(
            Investigation investigation)
        {
            _context.Investigations.Add(investigation);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetInvestigationById),
                new { id = investigation.InvestigationID },
                investigation
            );
        }

        [HttpGet("dapper")]
        public async Task<IActionResult> GetInvestigationsUsingDapper()
        {
            var connectionString =
                _configuration.GetConnectionString("TracePointConnection");

            using var connection = new MySqlConnection(connectionString);

            var sql = @"
                SELECT
                    i.InvestigationID,
                    s.Name AS SuspectName,
                    i.Conclusion,
                    i.DateStarted
                FROM Investigations i
                INNER JOIN Suspects s
                    ON i.SuspectID = s.SuspectID;
            ";

            var investigations = await connection.QueryAsync<InvestigationResult>(sql);

            return Ok(investigations);
        }

        // PUT api/<InvestigationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<InvestigationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
