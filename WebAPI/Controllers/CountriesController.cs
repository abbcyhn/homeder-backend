using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public CountriesController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> ListAll()
        {
            int countryId = 1;

            var countries = await _ctx.Countries
                .Include(x => x.CountryCodes)
                .ThenInclude(x => x.UserPhones)
                .Where(x => x.Id == countryId)
                .SelectMany(x => x.CountryCodes)
                .SelectMany(x => x.UserPhones)
                .ToListAsync();

            return Ok(countries);
        }
    }
}