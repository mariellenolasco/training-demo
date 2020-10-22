using System.Collections.Generic;
using HerosLib.Models;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
namespace HerosDB
{
    public class FileRepo : IRepository
    {
        private string filename = "HerosDB/Heroes/Heroes.txt";
        public async void AddAHeroAsync(Hero hero)
        {
            using (FileStream fs = File.Create(path: filename)){
                await JsonSerializer.SerializeAsync(fs, hero);
                System.Console.WriteLine("Hero being written to file");
            }

        }

        public async Task<List<Hero>> GetAllHeroesAsync()
        {
            List<Hero> allHeroes = new List<Hero>();
            using (FileStream fs = File.OpenRead(filename))
            {
                allHeroes.Add(await JsonSerializer.DeserializeAsync<Hero>(fs));
            }
            return allHeroes;

        }

        public Hero GetHeroByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}