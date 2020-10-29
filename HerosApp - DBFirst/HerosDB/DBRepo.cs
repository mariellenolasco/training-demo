using System.Collections.Generic;
using System.Threading.Tasks;
using HerosDB.Models;
using HerosDB.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HerosDB
{
    public class DBRepo : ISuperHeroRepo, IVillainRepo
    {
        private readonly HeroContext context;
        private readonly IMapper mapper;
        public DBRepo(HeroContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void AddAHeroAsync(SuperHero hero)
        {
            context.Superpeople.AddAsync(mapper.ParseSuperHero(hero));
            context.SaveChangesAsync();
        }

        public void AddAVillain(SuperVillain superVillain)
        {
            context.Superpeople.Add(mapper.ParseSuperVillain(superVillain));
            context.SaveChanges();
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

        public List<SuperVillain> GetAllVillains()
        {
            return mapper.ParseSuperVillain(
                    context.Superpeople
                    .Where(x => x.Chartype == context.Charactertype.Single(y => y.Chartype == "Supervillain").Id)
                    .Include("Powers")
                    .ToList());
        }

        public SuperHero GetHeroByName(string name)
        {
            return mapper.ParseSuperHero(context.Superpeople.Include("Powers").SingleOrDefault(x => x.Workname == name));
        }

        public SuperVillain GetVillainByName(string name)
        {
            return mapper.ParseSuperVillain(context.Superpeople.Include("Powers").SingleOrDefault(x => x.Workname == name));
        }
    }
}