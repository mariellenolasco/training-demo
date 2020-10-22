using HerosLib.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace HerosDB
{
    public interface IRepository
    {
         Task<List<Hero>> GetAllHeroesAsync();
         void AddAHeroAsync(Hero hero);
         Hero GetHeroByName(string name);
    }
}