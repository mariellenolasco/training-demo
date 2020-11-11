using HerosDB.Models;
using HerosDB;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HerosLib
{
    public class HeroService : IHeroService
    {
        private ISuperHeroRepo repo;

        public HeroService(ISuperHeroRepo repo)
        {
            this.repo = repo;
        }
        public void AddHero(SuperHero newHero)
        {
            //Making sure aliases are unique before adding
            Task<List<SuperHero>> getHerosTask = repo.GetAllHeroesAsync();
            foreach (var hero in getHerosTask.Result)
            {
                if (newHero.Alias.Equals(hero.Alias))
                {
                    throw new Exception("Hero aliases should be unique. That superhero already exists in our db");
                }
            }
            repo.AddAHeroAsync(newHero);

        }
        public List<SuperHero> GetAllHeroes()
        {
            Task<List<SuperHero>> getHerosTask = repo.GetAllHeroesAsync();
            return getHerosTask.Result;
        }
        public SuperHero GetHeroByName(string alias)
        {
            return repo.GetHeroByName(alias);
        }
    }
}