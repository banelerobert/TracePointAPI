using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TracePointAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TracePointAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvidenceController : ControllerBase
    {

        private readonly TracePointDbContext _context;

        public EvidenceController(TracePointDbContext context)
        {
            _context = context;
        }

        // GET: api/<EvidenceController>
        [HttpGet]
        public async Task<IActionResult> GetEvidence()
        {
            var evidence = await _context.Evidence.ToListAsync();

            return Ok(evidence);
        }


        // GET api/<EvidenceController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEvidenceById(int id)
        {
            var evidence = await _context.Evidence.FindAsync(id);

            if (evidence == null)
            {
                return NotFound();
            }

            return Ok(evidence);
        }
        // POST api/<EvidenceController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<EvidenceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<EvidenceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
