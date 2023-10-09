using cursoandroid2023.API.Data;
using cursoandroid2023.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
