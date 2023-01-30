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


        //Get the list of heroes
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        //Get a single hero
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null) { return BadRequest("Hero not found"); }
            return Ok(hero);
        }

        //Post a hero to the list
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> addHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        //Update a hero with put
        [HttpPut]
        public async Task<ActionResult<SuperHero>> updateHero(SuperHero request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null) { return BadRequest("Hero not found"); }

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(heroes);
        }

        //Delete a hero

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> deleteHero(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if(hero == null) { return BadRequest("Hero not found"); }
            heroes.Remove(hero);
            return Ok(heroes);
        }

    }
}
