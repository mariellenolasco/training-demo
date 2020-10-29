using HerosDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace HerosDB
{
    public interface ISuperHeroRepo
    {
         Task<List<SuperHero>> GetAllHeroesAsync();
         void AddAHeroAsync(SuperHero hero);
         SuperHero GetHeroByName(string name);
    }
}