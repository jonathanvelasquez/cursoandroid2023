using cursoandroid2023.API.Data;
using cursoandroid2023.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace cursoandroid2023.API.Controllers
{
    
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController : ControllerBase   
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country) 
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {           
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Country country)
        {
            _context.Update(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id) 
        {
            var afectrows = await _context.Countries.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (afectrows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
