using System.Collections.Generic;
using System.Threading.Tasks;
using HerosDB.Models;
using HerosDB.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HerosDB
{
    public class DBRepo : ISuperHeroRepo
    {
        private readonly HeroContext context;
        private readonly ISuperHeroMapper mapper;
        public DBRepo(HeroContext context, ISuperHeroMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void AddAHeroAsync(SuperHero hero)
        {
            context.Superpeople.AddAsync(mapper.ParseSuperHero(hero));
            context.SaveChangesAsync();
        }

        public Task<List<SuperHero>> GetAllHeroesAsync()
        {
            int heroType = context.Charactertype.Single(x => x.Chartype == "Superhero").Id;
            return Task.Run<List<SuperHero>>(
                () => mapper.ParseSuperHero(
                    context.Superpeople
                    .Where(x => x.Chartype == heroType)
                    .Include("Powers")
                    .ToList()));
        }

        public SuperHero GetHeroByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}