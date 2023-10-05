using Domain.Regions;
using Domain.Users;
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

            var query = _ctx.GetEntity<Country>()
                .Include(x => x.CountryCodes)
                .ThenInclude(x => x.UserPhones)
                .Where(x => x.Id == countryId)
                .SelectMany(x => x.CountryCodes)
                .SelectMany(x => x.UserPhones);

            var queryString =  query.ToQueryString();

            Console.WriteLine(queryString);

            await query.ToListAsync();


            var user = new User();
            _ctx.GetEntity<User>().Add(user);

            await _ctx.GetEntity<User>().ToListAsync();
            await _ctx.GetEntity<Country>().ToListAsync();
            await _ctx.GetEntity<CountryCode>().ToListAsync();
            await _ctx.GetEntity<Citizenship>().ToListAsync();

            return Ok("All good");
        }
    }
}