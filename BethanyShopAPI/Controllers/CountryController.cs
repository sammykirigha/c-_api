using BethanyShopAPI.models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace BethanyShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private static List<Country> countries = new List<Country>
        { };

        private readonly AppDbContext appDbContext;

        public CountryController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetCountries()
        {

            return Ok(await appDbContext.Countries.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountryById(int countryId)
        {
            var country = await appDbContext.Countries.FindAsync(countryId);
            if (country == null) return BadRequest("Country with that id was not found");
            return Ok(country);
        }
    }
}
