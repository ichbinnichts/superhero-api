using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : Controller
    {
        private static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero { 
                    Id = 1,
                    Name = "Spider man",
                    FirstName= "Peter",
                    LastName="Parker",
                    Place="New York City" },

            new SuperHero { 
                    Id = 2,
                    Name="Iron man",
                    FirstName="Tony",
                    LastName="Stark",
                    Place="Long Island"}
        };
        
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> addHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }
    }
}
