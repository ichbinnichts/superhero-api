using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : Controller
    {
        
        //Constructor

        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        //Get the list of heroes
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        //Get a single hero
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null) { return BadRequest("Hero not found"); }
            return Ok(hero);
        }

        //Post a hero to the list
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> addHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        //Update a hero with put
        [HttpPut]
        public async Task<ActionResult<SuperHero>> updateHero(SuperHero request)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(request.Id);
            if (dbHero == null) { return BadRequest("Hero not found"); }

            dbHero.Name = request.Name;
            dbHero.FirstName = request.FirstName;
            dbHero.LastName = request.LastName;
            dbHero.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        //Delete a hero

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> deleteHero(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if(dbHero == null) { return BadRequest("Hero not found"); }

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

    }
}
