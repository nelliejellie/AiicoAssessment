using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace AiicoRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : ControllerBase
    {
        private readonly IConfiguration _config;
        public SuperheroController(IConfiguration config)
        {

            _config = config;

        }

        [HttpGet("GetAllHeroes")]
        public async Task<ActionResult<List<Superhero>>> GetAllSuperHeroes()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var heroes = await connection.QueryAsync<Superhero>("select * from superheroes");
            return Ok(heroes);
        }

        [HttpGet("GetAllHeroes/{id}")]
        public async Task<ActionResult<Superhero>> GetSuperHero(int id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var hero = await connection.QueryAsync<Superhero>("select * from superheroes where id = @Id", new
            {
                Id = id
            });
            return Ok(hero);
        }

        [HttpPost("CreateAHero")]
        public async Task<ActionResult<Superhero>> CreatSuperHero(Superhero hero)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into superheroes (name, firstname, lastname, place) values (@Name, @FirstName, @LastName, @Place)", hero);
            return Ok(hero);
        }

        [HttpPut("UpdateAHero")]
        public async Task<ActionResult<Superhero>> UpdateSuperHero(Superhero hero)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update into superheroes set name=@Name, firstname = @FirstName, lastname = @LastName, place= @Place where id = @Id", hero);
            return Ok(hero);
        }
    }
}
