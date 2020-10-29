using System.Collections.Generic;
using System.Threading.Tasks;
using HerosDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HerosDB
{
    public class DBRepo : ISuperHeroRepo, IVillainRepo
    {
        private readonly HeroContext context;
        public DBRepo(HeroContext context){
            this.context = context;
        }
        public void AddAHeroAsync(SuperHero hero)
        {
            context.SuperHeroes.AddAsync(hero);
            context.SaveChangesAsync();
        }

        public void AddAVillain(SuperVillain superVillain)
        {
            context.SuperVillains.AddAsync(superVillain);
            context.SaveChangesAsync();
        }

        public Task<List<SuperHero>> GetAllHeroesAsync()
        {

            return context.SuperHeroes.Select(x => x).ToListAsync();
        }

        public List<SuperVillain> GetAllVillains()
        {
            throw new System.NotImplementedException();
        }

        public SuperHero GetHeroByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public SuperVillain GetVillainByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}