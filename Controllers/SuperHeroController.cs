using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var heroes = new List<SuperHero>
            {
                new SuperHero { Id = 1, Name = "Spider man",
                    FirstName= "Peter", LastName="Parker",
                    Place="New York City" }
            };
            return Ok(heroes);
        }
    }
}
