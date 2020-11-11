using HerosDB.Models;
using HerosLib;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HerosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private readonly IHeroService _heroService;

        public SuperHeroController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetAllHeroes()
        {
            List<SuperHero> result = _heroService.GetAllHeroes();
            return Ok(result);
        }

        [HttpGet("{name}")]
        [Produces("application/json")]
        public IActionResult GetHeroByName(string name)
        {
            //needs error handling
            return Ok(_heroService.GetHeroByName(name));
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        public IActionResult AddHero(SuperHero newHero)
        {
            _heroService.AddHero(newHero);
            return CreatedAtAction("AddHero", newHero);
        }
    }
}