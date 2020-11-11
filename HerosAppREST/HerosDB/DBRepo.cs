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
            context.Superpeople.Add(mapper.ParseSuperHero(hero));
            context.SaveChanges();
        }

        public void AddAVillain(SuperVillain superVillain)
        {
            context.Superpeople.Add(mapper.ParseSuperVillain(superVillain));
            context.SaveChanges();
        }

        public Task<List<SuperHero>> GetAllHeroesAsync()
        {
           Task<List<SuperHero>> getHeroes =  Task.Run<List<SuperHero>>(
               () => mapper.ParseSuperHero(
                   context.Superpeople
                   .Include("Powers")
                   .Where(x => x.Chartype == context.Charactertype.Single(c => c.Chartype == "Superhero").Id)
                   .ToList()
               ));
            foreach(var hero in getHeroes.Result)
            {
                hero.Nemesis = new List<SuperVillain>();
                var villains = context.Enemies.Where(x => x.Heroid == hero.Id).ToList();
                foreach(var villain in villains) {
                    hero.Nemesis.Add(mapper.ParseSuperVillain(context.Superpeople.Single(x => x.Id == villain.Villainid)));
                }
                
            }
            return getHeroes;
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
            return mapper.ParseSuperHero(context.Superpeople.Include("Powers").First(x => x.Workname == name));
        }

        public SuperVillain GetVillainByName(string name)
        {
            return mapper.ParseSuperVillain(context.Superpeople.Include("Powers").SingleOrDefault(x => x.Workname == name));
        }
    }
}