using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TracePointAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TracePointAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly TracePointDbContext _context;

        public CasesController(TracePointDbContext context)
        {
            _context = context;
        }

        // GET: api/<CasesController>
        [HttpGet]
        public async Task<IActionResult> GetCases()
        {
            var cases = await _context.Cases.ToListAsync();

            return Ok(cases);
        }

        // GET api/<CasesController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCaseById(int id)
        {
            var caseItem = await _context.Cases.FindAsync(id);

            if (caseItem == null)
            { 
                return NotFound();
            }

            return Ok(caseItem);
        }

        // POST api/<CasesController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<CasesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<CasesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
