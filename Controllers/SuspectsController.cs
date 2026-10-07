using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TracePointAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TracePointAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuspectsController : ControllerBase
    {
        private readonly TracePointDbContext _context;

        public SuspectsController(TracePointDbContext context)
        {
            _context = context;
        }


        // GET: api/<SuspectsController>
        [HttpGet]
        public async Task<IActionResult> GetAllSuspects()
        {
            var suspects = await _context.Suspects.ToListAsync();

            return Ok(suspects);
        }



        // GET api/<SuspectsController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSuspectById(int id)
        {
            var suspect = await _context.Suspects
                .FirstOrDefaultAsync(s => s.SuspectID == id);

            if (suspect == null)
            {
                return NotFound("Suspect not found.");
            }

            return Ok(suspect);
        }
        // POST api/<SuspectsController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<SuspectsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<SuspectsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
