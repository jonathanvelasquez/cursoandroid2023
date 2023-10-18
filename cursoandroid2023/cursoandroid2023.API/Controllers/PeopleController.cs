using cursoandroid2023.API.Data;
using cursoandroid2023.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cursoandroid2023.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/people")]
    public class PeopleController : ControllerBase
    {
        private readonly DataContext _context;

        public PeopleController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Person person)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var person = await _context.People.FirstOrDefaultAsync(x => x.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.People.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Person person)
        {
            _context.Update(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var afectrows = await _context.People.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (afectrows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
