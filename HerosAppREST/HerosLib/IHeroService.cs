using HerosDB.Models;
using System.Collections.Generic;

namespace HerosLib
{
    public interface IHeroService
    {
        void AddHero(SuperHero newHero);
        List<SuperHero> GetAllHeroes();
        SuperHero GetHeroByName(string alias);
    }
}